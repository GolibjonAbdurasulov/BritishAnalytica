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
    public async Task<ResponseModelBase> CreateAsync(HomeModelDto dto)
    {
        var entity = new HomeModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body,
            ImageIds = dto.ImageIds,
            Name = dto.Name
        };
        await HomeModelRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
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
    public async Task<ResponseModelBase> UpdateAsync(HomeModelDto dto, long id)
    {
        var res = await HomeModelRepository.GetByIdAsync(id);
        res.Title = dto.Title;
        res.Body = dto.Body;
        res.ImageIds = dto.ImageIds;
        res.Name = dto.Name;
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
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = await HomeModelRepository.FirstOrDefaultAsync();
        var dto = new HomeModelDto()
        {
            Title = res.Title,
            Body = res.Body,
            ImageIds = res.ImageIds.ToList(),
            Name = res.Name
        };
        return new ResponseModelBase(dto);
    }
}

