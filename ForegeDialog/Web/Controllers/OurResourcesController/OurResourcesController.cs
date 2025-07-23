using DatabaseBroker.Repositories.OurResourcesRepository;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.OurResourcesController.OurResourcesDtos;

namespace Web.Controllers.OurResourcesController;
[ApiController]
[Route("[controller]/[action]")]
public class OurResourcesController : ControllerBase
{
    public IOurResourcesRepository OurResourcesRepository { get; set; }

    public OurResourcesController(IOurResourcesRepository ourResourcesRepository)
    {
        OurResourcesRepository = ourResourcesRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( OurResourcesCreationDto dto)
    {
        var entity = new OurResources()
        {
            Title = dto.Title,
            Description = dto.Description,
            FilePath = dto.FilePath,
        };
        var resEntity=await OurResourcesRepository.AddAsync(entity);
        
        var resDto = new OurResourcesDto()
        {
            Id = resEntity.Id,
            Title = resEntity.Title,
            Description = resEntity.Description,
            FilePath = resEntity.FilePath,
        };
        return new ResponseModelBase(resDto);
    }


  
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( OurResourcesDto dto)
    {
        var res =  await OurResourcesRepository.GetByIdAsync(dto.Id);
        res.Description = dto.Description;
        res.Title=dto.Title;
        res.FilePath=dto.FilePath;
      
        await OurResourcesRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        
        var res =  await OurResourcesRepository.GetByIdAsync(id);
        await OurResourcesRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await OurResourcesRepository.GetByIdAsync(id);
        var dto = new OurResourcesDto
        {
            Id = res.Id,
            Title = res.Title,
            Description = res.Description,
            FilePath = res.FilePath
        };
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res =   OurResourcesRepository.GetAllAsQueryable().ToList();
        List<OurResourcesDto> dtos = new List<OurResourcesDto>();
        foreach (OurResources question in res)
        {
            dtos.Add(new OurResourcesDto
            {
                Id = question.Id,
                Title = question.Title,
                Description = question.Description,
                FilePath =  question.FilePath
            });
        }
        
        return new ResponseModelBase(dtos);
    }
}