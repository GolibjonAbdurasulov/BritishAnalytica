using DatabaseBroker.Repositories.OurValuedClientsRepository;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.OurValuedClientsController.OurValuedClientsDtos;

namespace Web.Controllers.OurValuedClientsController;
[ApiController]
[Route("[controller]/[action]")]
public class OurValuedClientsController : ControllerBase
{
    public IOurValuedClientsRepository OurValuedClientsRepository { get; set; }

    public OurValuedClientsController(IOurValuedClientsRepository ourValuedClientsRepository)
    {
        this.OurValuedClientsRepository = ourValuedClientsRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( OurValuedClientsCreationDto dto)
    {
        var entity = new OurValuedClients
        {
            CompanyName = dto.CompanyName,
            ImagePath = dto.ImagePath,
            link = dto.link,
        };
        var resEntity=await OurValuedClientsRepository.AddAsync(entity);
        
        var resDto = new OurValuedClientsDto
        {
            Id = resEntity.Id,
            CompanyName = resEntity.CompanyName,
            ImagePath = resEntity.ImagePath,
            link = resEntity.link,
        };
        return new ResponseModelBase(resDto);
    }


  
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( OurValuedClientsDto dto)
    {
        var res =  await OurValuedClientsRepository.GetByIdAsync(dto.Id);
        res.CompanyName = dto.CompanyName;
        res.ImagePath=dto.ImagePath;
        res.link=dto.link;
        await OurValuedClientsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        
        var res =  await OurValuedClientsRepository.GetByIdAsync(id);
        await OurValuedClientsRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await OurValuedClientsRepository.GetByIdAsync(id);
        var dto = new OurValuedClientsDto
        {
            Id = res.Id,
            CompanyName = res.CompanyName,
            ImagePath = res.ImagePath,
            link = res.link,
        };
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res =   OurValuedClientsRepository.GetAllAsQueryable().ToList();
        List<OurValuedClientsDto> dtos = new List<OurValuedClientsDto>();
        foreach (OurValuedClients question in res)
        {
            dtos.Add(new OurValuedClientsDto
            {
                Id = question.Id,
                CompanyName = question.CompanyName,
                ImagePath = question.ImagePath,
                link = question.link,
            });
        }
        
        return new ResponseModelBase(dtos);
    }   
}