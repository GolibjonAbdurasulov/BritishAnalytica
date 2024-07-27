using DatabaseBroker.Repositories.AboutBusinessModelRepository;
using DatabaseBroker.Repositories.ReasonRepositories;
using Entity.Models.AboutBusinessModel;
using Entity.Models.FutureModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.AboutBusinessController.Dtos;

namespace Web.Controllers.AboutBusinessController;

[ApiController]
[Route("[controller]/[action]")]
public class AboutBusinessModelController : ControllerBase
{
    private IAboutBusinessModelRepository AboutBusinessModelRepository { get; set; }
private IReasonRepository ReasonRepository { get; set; }
    public AboutBusinessModelController(IAboutBusinessModelRepository aboutBusinessModelRepository, IReasonRepository reasonRepository)
    {
        AboutBusinessModelRepository = aboutBusinessModelRepository;
        ReasonRepository = reasonRepository;
    }


    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(AboutBusinessCreationDto dto)
    {
        List<Reason> reasons = await DtoToModel(dto.ReasonDtos);
        var aboutBusiness = new AboutBusinessModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            About = dto.About,
            Reasons = reasons,
            ImageId = dto.ImageId,
            MiniTitle = dto.MiniTitle
        };
        await AboutBusinessModelRepository.AddAsync(aboutBusiness);

        List<ReasonDto> reasonDtos = await DtoToDto(dto.ReasonDtos);
        
        var resDto = new AboutBusinessDto
        {
            Id = aboutBusiness.Id,
            Title = aboutBusiness.Title,
            MiniTitle = aboutBusiness.MiniTitle,
            ReasonDtos = reasonDtos,
            About = aboutBusiness.About,
            ImageId = default
        };
        
        return new ResponseModelBase(resDto);
    } 
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( AboutBusinessDto dto)
    {
        var res = await AboutBusinessModelRepository.GetByIdAsync(dto.Id);
        res.MiniTitle = dto.MiniTitle;
        res.About = dto.About;
        res.Title = dto.Title;
        res.ImageId = dto.ImageId;
        res.UpdatedAt=DateTime.Now;
        res.UpdatedAt=DateTime.Now;
        await AboutBusinessModelRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateReasonAsync(ReasonDto dto)
    {
        var res = await ReasonRepository.GetByIdAsync(dto.Id);

        res.Text = dto.Text;
        await ReasonRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =  await AboutBusinessModelRepository.GetByIdAsync(id);
        await AboutBusinessModelRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteFutureAsync(long id)
    {
        var res =  await ReasonRepository.GetByIdAsync(id);
        await ReasonRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync(long id)
    {
        var res = await AboutBusinessModelRepository.GetByIdAsync(id);
        List<ReasonDto> reasonDtos = await ModelToDto(res.Reasons);
        var dto = new AboutBusinessDto
        {
            Id = res.Id,
            Title = res.Title,
            About = res.About,
            MiniTitle = res.MiniTitle,
            ReasonDtos = reasonDtos,
            ImageId = res.ImageId
        };
        return new ResponseModelBase(dto);
    }


    private async Task<List<Reason>> DtoToModel(List<ReasonCreationDto> dtos)
    {
        List<Reason> reasons = new List<Reason>();
        foreach (ReasonCreationDto dto in dtos)
        {
            var future = new Reason()
            {
                Text = dto.Text
            };
            reasons.Add(future);
        }

        return reasons;
    }
    private async Task<List<ReasonDto>> ModelToDto(List<Reason> models)
    {
        List<ReasonDto> reasonDtos = new List<ReasonDto>();
        foreach (Reason model in models)
        {
            var future = new ReasonDto()
            {
                Id = model.Id,
                Text = model.Text
            };
            reasonDtos.Add(future);
        }

        return reasonDtos;
    }
    
    private async Task<List<ReasonDto>> DtoToDto(List<ReasonCreationDto> creationDtos)
    {
        List<ReasonDto> reasonDtos = new List<ReasonDto>();
        foreach (ReasonCreationDto model in creationDtos)
        {
            var future = new ReasonDto()
            {
                Text = model.Text
            };
            reasonDtos.Add(future);
        }

        return reasonDtos;
    }
}