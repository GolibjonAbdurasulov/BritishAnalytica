using DatabaseBroker.Repositories.PpsRepository;
using Entity.Models.PPS;
using Entity.Models.PPS.PlaningModel;
using Entity.Models.PPS.ProjectModel;
using Entity.Models.PPS.SuccessModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Common;
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =  await PpsRepository.GetByIdAsync(id);
        await PpsRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = await PpsRepository.FirstOrDefaultAsync();
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