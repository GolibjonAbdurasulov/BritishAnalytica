using DatabaseBroker.Repositories.OurValuesRepository;
using Entity.Models.OurServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.OurValuesController.OurValueDtos;

namespace Web.Controllers.OurValuesController;
[ApiController]
[Route("[controller]/[action]")]
public class OurValuesController : ControllerBase
{
    private IOurValuesRepository OurValuesRepository { get; set; }

    public OurValuesController(IOurValuesRepository ourValuesRepository)
    {
        OurValuesRepository = ourValuesRepository;
    }
    
    
    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(OurValueCreationDto dto)
    {
        var entity = new OurValues()
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AboutValue = dto.AboutValue,
            ValueName = dto.ValueName
        };
        
        var service = await OurValuesRepository.AddAsync(entity);

        var ourValueDto = new OurValueDto()
        {
            Id = service.Id,
            AboutValue = service.AboutValue,
            ValueName = service.ValueName
        };
        return new ResponseModelBase(ourValueDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(OurValueDto dto)
    {
        var res = await OurValuesRepository.GetByIdAsync(dto.Id);
        res.AboutValue = dto.AboutValue;
        res.ValueName = dto.ValueName;
        res.UpdatedAt = DateTime.Now;

        res.UpdatedAt=DateTime.Now;
        await OurValuesRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = await OurValuesRepository.GetByIdAsync(id);
        await OurValuesRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await OurValuesRepository.GetByIdAsync(id);
        var dto = new OurValueDto()
        {
            Id=res.Id,
            AboutValue = res.AboutValue,
            ValueName= res.ValueName
        };
        
        return new ResponseModelBase(dto);
    }
    
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = OurValuesRepository.GetAllAsQueryable().ToList();
        List<OurValueDto> values = new List<OurValueDto>();
        foreach (var ourValues in res)
        {
            values.Add(new OurValueDto()
            {
                Id=ourValues.Id,
                AboutValue = ourValues.AboutValue,
                ValueName = ourValues.ValueName
            });
        }
        return new ResponseModelBase(values);
    }   
}