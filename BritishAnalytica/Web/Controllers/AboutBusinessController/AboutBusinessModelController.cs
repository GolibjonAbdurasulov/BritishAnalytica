using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.AboutBusinessModelRepository;
using DatabaseBroker.Repositories.FutureRepository;
using Entity.Models.AboutBusinessModel;
using Entity.Models.FutureModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Common;
using Web.Controllers.AboutBusinessController.Dtos;

namespace Web.Controllers.AboutBusinessController;

[ApiController]
[Route("[controller]/[action]")]
public class AboutBusinessModelController : ControllerBase
{
    private IAboutBusinessModelRepository AboutBusinessModelRepository { get; set; }
    private IFutureRepository FutureRepository { get; set; }

    public AboutBusinessModelController(IAboutBusinessModelRepository aboutBusinessModelRepository, IFutureRepository futureRepository)
    {
        AboutBusinessModelRepository = aboutBusinessModelRepository;
        FutureRepository = futureRepository;
    }


    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(AboutBusinessCreationDto dto)
    {
        List<Future> futures = await DtoToModel(dto.Futures);
        var aboutBusiness = new AboutBusinessModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body,
            Futures = futures,
            ImageId = dto.ImageId
        };
        await AboutBusinessModelRepository.AddAsync(aboutBusiness);

        List<FutureDto> futureDtos = await DtoToDto(dto.Futures);
        
        var resDto = new AboutBusinessDto
        {
            Id = aboutBusiness.Id,
            Title = aboutBusiness.Title,
            Body = aboutBusiness.Body,
            Futures = futureDtos,
            ImageId = default
        };
        
        return new ResponseModelBase(resDto);
    } 
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( AboutBusinessDto dto)
    {
        var res = await AboutBusinessModelRepository.GetByIdAsync(dto.Id);
        res.Body = dto.Body;
        res.Title = dto.Title;
        res.ImageId = dto.ImageId;
        res.UpdatedAt=DateTime.Now;
        await AboutBusinessModelRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateFuturesAsync(FutureDto dto)
    {
        var res = await FutureRepository.GetByIdAsync(dto.Id);

        res.Text = dto.Text;
        await FutureRepository.UpdateAsync(res);
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
        var res =  await FutureRepository.GetByIdAsync(id);
        await FutureRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync(long id)
    {
        var res = await AboutBusinessModelRepository.GetByIdAsync(id);
        List<FutureDto> futures = await ModelToDto(res.Futures);
        var dto = new AboutBusinessDto
        {
            Title = res.Title,
            Body = res.Body,
            Futures = futures,
            ImageId = res.ImageId
        };
        return new ResponseModelBase(dto);
    }


    private async Task<List<Future>> DtoToModel(List<FutureCreationDto> dtos)
    {
        List<Future> futures = new List<Future>();
        foreach (FutureCreationDto dto in dtos)
        {
            var future = new Future
            {
                Text = dto.Text
            };
            futures.Add(future);
        }

        return futures;
    }
    private async Task<List<FutureDto>> ModelToDto(List<Future> models)
    {
        List<FutureDto> futures = new List<FutureDto>();
        foreach (Future model in models)
        {
            var future = new FutureDto
            {
                Text = model.Text
            };
            futures.Add(future);
        }

        return futures;
    }
    
    private async Task<List<FutureDto>> DtoToDto(List<FutureCreationDto> creationDtos)
    {
        List<FutureDto> futures = new List<FutureDto>();
        foreach (FutureCreationDto model in creationDtos)
        {
            var future = new FutureDto
            {
                Text = model.Text
            };
            futures.Add(future);
        }

        return futures;
    }
}