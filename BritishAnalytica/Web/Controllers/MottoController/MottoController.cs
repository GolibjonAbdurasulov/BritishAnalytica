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
    public async Task<ResponseModelBase> CreateAsync(MottoDto dto)
    {
        var entity = new Motto()
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Text = dto.Text,
            Author = dto.Author,
            Name = dto.Name
        };
        await MottoRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(MottoDto dto, long id)
    {
        var res = await MottoRepository.GetByIdAsync(id);
        res.Text = dto.Text;
        res.Author = dto.Author;
        res.Name = dto.Name;

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
            Author = res.Author,
            Text = res.Text,
            Name = res.Name
        };
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync(long id)
    {
        var res = MottoRepository.GetAllAsQueryable().ToList();
        List<MottoDto> dtos = new List<MottoDto>();
        foreach (Motto motto in res)
        {
            var dto = new MottoDto
            {
                Author = motto.Author,
                Text = motto.Text,
                Name = motto.Name
            };
            dtos.Add(dto);
        }
        
        return new ResponseModelBase(dtos);
    }
}