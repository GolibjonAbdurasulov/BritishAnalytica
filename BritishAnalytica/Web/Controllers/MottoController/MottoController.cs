using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.MottoRepository;
using Entity.Models.Motto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.MottoController.MottoDtos;

namespace Web.Controllers.MottoController;

[ApiController]
[Route("[controller]/[action]")]
public class MottoController : ControllerBase
{
    private IMottoRepository MottoRepository { get; set; }

    public MottoController(IMottoRepository mottoRepository)
    {
        MottoRepository = mottoRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(MottoCreationDto dto)
    {
        var entity = new Motto()
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Text = dto.Text,
            Author = dto.Author
        };
       var resEntity= await MottoRepository.AddAsync(entity);
       var mottoDto = new MottoDto
       {
           Id = resEntity.Id,
           Author = dto.Author,
           Text = dto.Text
       };

       return new ResponseModelBase(mottoDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(MottoDto dto)
    {
        var res = await MottoRepository.GetByIdAsync(dto.Id);
        res.Text = dto.Text;
        res.Author = dto.Author;

        await MottoRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =await MottoRepository.GetByIdAsync(id);
        await MottoRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =await MottoRepository.GetByIdAsync(id);
        var dto = new MottoDto
        {
            Id=res.Id,
            Author = res.Author,
            Text = res.Text
        };
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = MottoRepository.GetAllAsQueryable().ToList();
        List<MottoDto> dtos = new List<MottoDto>();
        foreach (Motto motto in res)
        {
            var dto = new MottoDto
            {
                Id=motto.Id,
                Author = motto.Author,
                Text = motto.Text
            };
            dtos.Add(dto);
        }
        
        return new ResponseModelBase(dtos);
    }
}
