using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ServicePercentRepository;
using Entity.Models.ServicePercent;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.ServicePercentController.ServicePercentDtos;

namespace Web.Controllers.ServicePercentController;


[ApiController]
[Route("[controller]/[action]")]
public class ServicePercentController : ControllerBase
{
    private IServicePercentRepository ServicePercentRepository { get; set; }

    public ServicePercentController(IServicePercentRepository servicePercentRepository)
    {
        ServicePercentRepository = servicePercentRepository;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync(ServicePercentDto dto)
    {
        var entity = new ServicePercent
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ServiceName = dto.ServiceName,
            ServicePerecnt = dto.ServicePerecnt
        };
        await ServicePercentRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(ServicePercentDto dto, long id)
    {
        var res = await ServicePercentRepository.GetByIdAsync(id);
        res.ServiceName = dto.ServiceName;
        res.ServicePerecnt = dto.ServicePerecnt;
        res.UpdatedAt = DateTime.Now;

        await ServicePercentRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = ServicePercentRepository.FirstOrDefault();
        await ServicePercentRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res = ServicePercentRepository.LastOrDefault();
        var dto = new ServicePercentDto()
        {
            ServiceName = res.ServiceName,
            ServicePerecnt = res.ServicePerecnt
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = ServicePercentRepository.GetAllAsQueryable().ToList();
        return new ResponseModelBase(res);
    }

}