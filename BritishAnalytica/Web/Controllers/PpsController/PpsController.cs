using DatabaseBroker.Repositories.PpsRepository;
using DatabaseBroker.Repositories.PpsRepository.PlaningRepository;
using DatabaseBroker.Repositories.PpsRepository.ProjectRepository;
using DatabaseBroker.Repositories.PpsRepository.SuccessRepository;
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
    private IProjectRepository ProjectRepository { get; set; }
    private IPlaningRepository PlaningRepository { get; set; }
    private ISuccessRepository SuccessRepository { get; set; }

    public PpsController(IPpsRepository ppsRepository, IProjectRepository projectRepository, IPlaningRepository planingRepository, ISuccessRepository successRepository)
    {
        PpsRepository = ppsRepository;
        ProjectRepository = projectRepository;
        PlaningRepository = planingRepository;
        SuccessRepository = successRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(PpsModelCreationDto dto)
    {
        var entity = new PpsModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Project = new Project
            {
                Title = dto.ProjectDto.Title,
                Body = dto.ProjectDto.Title
            },
            Planing = new Planing
            {
                Title = dto.PlaningDto.Title,
                Body = dto.PlaningDto.Body
            },
            Success = new Success
            {
                Title = dto.SuccessDto.Title,
                Body = dto.SuccessDto.Body
            }
        };
       var resEntity= await PpsRepository.AddAsync(entity);

       var ppsDto = new PpsModelDto
       {
           Id = resEntity.Id,
           PlaningDto = new PlaningDto
           {
               Id = resEntity.PlaningId,
               Title = resEntity.Planing.Title,
               Body = resEntity.Planing.Body
           },
           ProjectDto = new ProjectDto
           {
               Id = resEntity.ProjectId,
               Title = resEntity.Project.Title,
               Body = resEntity.Project.Body
           },
           SuccessDto = new SuccessDto
           {
               Id = resEntity.SuccessId,
               Title = resEntity.Success.Title,
               Body = resEntity.Success.Body
           }
       };

       return new ResponseModelBase(ppsDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateProjectAsync(PpsModelDto dto)
    {
        var res = await PpsRepository.GetByIdAsync(dto.Id);
        res.Project.Title = dto.ProjectDto.Title;
        res.Project.Body = dto.ProjectDto.Body;
        res.UpdatedAt = DateTime.Now;

        res.UpdatedAt=DateTime.Now;
        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdatePlaningAsync(PpsModelDto dto)
    {
        var res = await PpsRepository.GetByIdAsync(dto.Id);
        res.Planing.Title = dto.PlaningDto.Title;
        res.Planing.Body = dto.PlaningDto.Body;
        res.UpdatedAt = DateTime.Now;
        res.UpdatedAt=DateTime.Now;
        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    } 
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateSuccessAsync(PpsModelDto dto)
    {
        var res = await PpsRepository.GetByIdAsync(dto.Id);
        res.Success.Title = dto.SuccessDto.Title;
        res.Success.Body = dto.SuccessDto.Body;
        res.UpdatedAt = DateTime.Now;
        res.UpdatedAt=DateTime.Now;
        await PpsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }

    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var ppsModel =  await PpsRepository.GetByIdAsync(id);
        await PpsRepository.RemoveAsync(ppsModel);
        
        var planing = await PlaningRepository.GetByIdAsync(ppsModel.PlaningId);
        await PlaningRepository.RemoveAsync(planing);

        var project = await ProjectRepository.GetByIdAsync(ppsModel.ProjectId);
        await ProjectRepository.RemoveAsync(project);

        var success = await SuccessRepository.GetByIdAsync(ppsModel.SuccessId);
        await SuccessRepository.RemoveAsync(success);
        
        return new ResponseModelBase(ppsModel);
    }

    
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = await PpsRepository.FirstOrDefaultAsync();
        var dto = new PpsModelDto
        {
            Id = res.Id,
            PlaningDto = new PlaningDto
            {
                Id = res.PlaningId,
                Title = res.Planing.Title,
                Body = res.Planing.Body
            },
            ProjectDto = new ProjectDto
            {
                Id=res.ProjectId,
                Title = res.Project.Title,
                Body = res.Project.Body
            },
            SuccessDto = new SuccessDto
            {
                Id = res.SuccessId,
                Title = res.Success.Title,
                Body = res.Success.Body
            }
        };
        
        return new ResponseModelBase(dto);
    }
}