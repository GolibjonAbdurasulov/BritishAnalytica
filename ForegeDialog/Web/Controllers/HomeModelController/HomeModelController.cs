using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.HomeModelRepository;
using Entity.Models.HomeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Common;
using Web.Controllers.HomeModelController.HomeModelDtos;

namespace Web.Controllers.HomeModelController;

[ApiController]
[Route("[controller]/[action]")]
public class HomeModelController : ControllerBase
{
    private IHomeModelRepository HomeModelRepository { get; set; }

    public HomeModelController(IHomeModelRepository homeModelRepository)
    {
        HomeModelRepository = homeModelRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(HomeModelCreationDto dto)
    {
        var entity = new HomeModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Text = dto.Text,
            ImageId = dto.ImageId
        };
        var resEntity=await HomeModelRepository.AddAsync(entity);

        var homeModelDto = new HomeModelDto
        {
            Id = resEntity.Id,
            Text = resEntity.Text,
            ImageId = resEntity.ImageId
        };
        
        return new ResponseModelBase(homeModelDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateImageAsync(Guid id)
    {
        var res =  await HomeModelRepository.FirstOrDefaultAsync();
        res.ImageId = id;
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(id);
    }



    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(HomeModelDto dto)
    {
        var res = await HomeModelRepository.GetByIdAsync(dto.Id);
        res.Text = dto.Text;
        res.ImageId = dto.ImageId;
        res.UpdatedAt=DateTime.Now;
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }


    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var res =  await HomeModelRepository.FirstOrDefaultAsync();
        await HomeModelRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    

    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = await HomeModelRepository.FirstOrDefaultAsync();
        var dto = new HomeModelDto()
        {
            Id = res.Id,
            Text =res.Text,
            ImageId = res.ImageId
        };
        return new ResponseModelBase(dto);
    }
}

