using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.OurServicesRepository;
using DatabaseBroker.Repositories.PpsRepository;
using Entity.Models.OurServices;
using Entity.Models.PPS;
using Entity.Models.PPS.Planing;
using Entity.Models.PPS.Project;
using Entity.Models.PPS.Success;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.OurServicesController.OurServicesDtos;
using Web.Controllers.PpsController.PpsDtos;

namespace Web.Controllers.PpsController;

[ApiController]
[Route("[controller]/[action]")]
public class PpsController : ControllerBase
{
    private IPpsRepository PpsRepository { get; set; }

    public PpsController(IPpsRepository ppsRepository)
    {
        PpsRepository = ppsRepository;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync(PpsModelDto dto)
    {
        var entity = new PpsModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = dto.Name,
            Project = new Project
            {
                Title = dto.ProjectDto.Title,
                Body = dto.ProjectDto.Title,
                Name = dto.ProjectDto.Name
            },
            Planing = new Planing
            {
                Title = dto.PlaningDto.Title,
                Body = dto.PlaningDto.Body,
                Name = dto.PlaningDto.Name
            },
            Success = new Success
            {
                Title = dto.SuccessDto.Title,
                Body = dto.SuccessDto.Body,
                Name = dto.SuccessDto.Name
            }
        };
        await PpsRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdateProjectAsync(PpsModelDto dto, long id)
    {
        var res = await PpsRepository.GetByIdAsync(id);
        res.Project.Title = dto.ProjectDto.Title;
        res.Project.Body = dto.ProjectDto.Body;
        res.UpdatedAt = DateTime.Now;
        res.Name = dto.Name;

        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdatePalaningAsync(PpsModelDto dto, long id)
    {
        var res = await PpsRepository.GetByIdAsync(id);
        res.Planing.Title = dto.PlaningDto.Title;
        res.Planing.Body = dto.PlaningDto.Body;
        res.UpdatedAt = DateTime.Now;
        res.Name = dto.Name;
        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    } 
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdateSuccessAsync(PpsModelDto dto, long id)
    {
        var res = await PpsRepository.GetByIdAsync(id);
        res.Success.Title = dto.SuccessDto.Title;
        res.Success.Body = dto.SuccessDto.Body;
        res.UpdatedAt = DateTime.Now;
        res.Name = dto.Name;
        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }

    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = PpsRepository.FirstOrDefault();
        await PpsRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = PpsRepository.LastOrDefault();
        var dto = new PpsModelDto
        {
            PlaningDto = new PlaningDto
            {
                Title = res.Planing.Title,
                Body = res.Planing.Body,
                Name = res.Name
            },
            ProjectDto = new ProjectDto
            {
                Title = res.Project.Title,
                Body = res.Project.Body,
                Name = res.Name
            },
            SuccessDto = new SuccessDto
            {
                Title = res.Success.Title,
                Body = res.Success.Body,
                Name = res.Name
            },
            Name = res.Name
        };
        
        return new ResponseModelBase(dto);
    }
    
    
   
}