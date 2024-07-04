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
            Title = dto.Title,
            Body = dto.Body,
            ImageIds = dto.ImageIds
        };
        var resEntity=await HomeModelRepository.AddAsync(entity);

        var homeModelDto = new HomeModelDto
        {
            Id = resEntity.Id,
            Title = resEntity.Title,
            Body = resEntity.Body,
            ImageIds = resEntity.ImageIds
        };
        
        return new ResponseModelBase(homeModelDto);
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> AddImageAsync(Guid id)
    {
        var res =  await HomeModelRepository.FirstOrDefaultAsync();
        res.ImageIds.Add(id);
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(id);
    }



    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(HomeModelDto dto)
    {
        var res = await HomeModelRepository.GetByIdAsync(dto.Id);
        res.Title = dto.Title;
        res.Body = dto.Body;
        res.ImageIds = dto.ImageIds;
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
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteImageAsync(Guid id)
    {
        var res = await HomeModelRepository.FirstOrDefaultAsync();
        res.ImageIds.Remove(id);
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetAsync(long id)
    {
        var res = await HomeModelRepository.GetByIdAsync(id);
        var dto = new HomeModelDto()
        {
            Title = res.Title,
            Body = res.Body,
            ImageIds = res.ImageIds.ToList()
        };
        return new ResponseModelBase(dto);
    }
}

