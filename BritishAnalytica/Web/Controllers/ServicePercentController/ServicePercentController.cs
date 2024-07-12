using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.ServicePercentRepository;
using Entity.Models.ServicePercent;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(ServicePercentCreationDto dto)
    {
        var entity = new ServicePercent
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ServiceName = dto.ServiceName,
            ServicePerecnt = dto.ServicePerecnt
        };
       var resEntity =await ServicePercentRepository.AddAsync(entity);
       var servicePercentDto = new ServicePercentDto
       {
           Id=resEntity.Id,
           ServiceName = dto.ServiceName,
           ServicePerecnt = dto.ServicePerecnt
       };
       
       return new ResponseModelBase(dto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(ServicePercentDto dto)
    {
        var res = await ServicePercentRepository.GetByIdAsync(dto.Id);
        res.ServiceName = dto.ServiceName;
        res.ServicePerecnt = dto.ServicePerecnt;
        res.UpdatedAt = DateTime.Now;

        res.UpdatedAt=DateTime.Now;
        await ServicePercentRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = await ServicePercentRepository.GetByIdAsync(id);
        await ServicePercentRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await ServicePercentRepository.GetByIdAsync(id);
        var dto = new ServicePercentDto()
        {
            Id=res.Id,
            ServiceName = res.ServiceName,
            ServicePerecnt = res.ServicePerecnt
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = ServicePercentRepository.GetAllAsQueryable().ToList();
        List<ServicePercentDto> services = new List<ServicePercentDto>();
        foreach (var servicePercent in res)
        {
            services.Add(new ServicePercentDto
            {
                Id = servicePercent.Id,
                ServiceName = servicePercent.ServiceName,
                ServicePerecnt = servicePercent.ServicePerecnt
            });
        }
        return new ResponseModelBase(services);
    }

}