using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.HomeModelRepository;
using Entity.Models.HomeModel;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ResponseModelBase> CreateAsync(HomeModelDto dto)
    {
        var entity = new HomeModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body,
            ImageIds = dto.ImageIds
        };
        await HomeModelRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPost]
    public async Task<ResponseModelBase> AddImageAsync(Guid id)
    {
        var res = HomeModelRepository.LastOrDefault();
        res.ImageIds.Add(id);
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(id);
    }



    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(HomeModelDto dto, long id)
    {
        var res = await HomeModelRepository.GetByIdAsync(id);
        res.Title = dto.Title;
        res.Body = dto.Body;
        res.ImageIds = dto.ImageIds;

        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }


    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var res = HomeModelRepository.LastOrDefault();
        await HomeModelRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteImageAsync(Guid id)
    {
        var res = HomeModelRepository.LastOrDefault();
        res.ImageIds.Remove(id);
        await HomeModelRepository.UpdateAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = HomeModelRepository.LastOrDefault();
        var dto = new HomeModelDto()
        {
            Title = res.Title,
            Body = res.Body,
            ImageIds = res.ImageIds
        };
        return new ResponseModelBase(dto);
    }
}

