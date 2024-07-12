using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.OurServicesRepository;
using Entity.Models.OurServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.OurServicesController.OurServicesDtos;

namespace Web.Controllers.OurServicesController;


[ApiController]
[Route("[controller]/[action]")]
public class OurServicesController : ControllerBase
{
    private IOurServicesRepository OurServicesRepository { get; set; }

    public OurServicesController(IOurServicesRepository ourServicesRepository)
    {
        OurServicesRepository = ourServicesRepository;
    }
    
    
    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(OurServicesCreationDto dto)
    {
        var entity = new OurService
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ServiceName = dto.ServiceName,
            AboutService = dto.AboutService,
            ServiceIconId = dto.ServiceIconId
        };
        
        var service = await OurServicesRepository.AddAsync(entity);

        var ourServicesDto = new OurServicesDto
        {
            Id = service.Id,
            ServiceName = service.ServiceName,
            AboutService = service.AboutService,
            ServiceIconId = service.ServiceIconId
        };
        return new ResponseModelBase(ourServicesDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(OurServicesDto dto)
    {
        var res = await OurServicesRepository.GetByIdAsync(dto.Id);
        res.AboutService = dto.AboutService;
        res.ServiceName = dto.ServiceName;
        res.ServiceIconId = dto.ServiceIconId;
        res.UpdatedAt = DateTime.Now;

        res.UpdatedAt=DateTime.Now;
        await OurServicesRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = await OurServicesRepository.GetByIdAsync(id);
        await OurServicesRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await OurServicesRepository.GetByIdAsync(id);
        var dto = new OurServicesDto
        {
            Id=res.Id,
            ServiceName = res.ServiceName,
            AboutService = res.AboutService,
            ServiceIconId = res.ServiceIconId,
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = OurServicesRepository.GetAllAsQueryable().ToList();
        List<OurService> services = new List<OurService>();
        foreach (var ourService in res)
        {
            services.Add(new OurService
            {
                Id=ourService.Id,
                ServiceName = ourService.ServiceName,
                AboutService = ourService.AboutService,
                ServiceIconId = ourService.ServiceIconId
            });
        }
        return new ResponseModelBase(services);
    }
}