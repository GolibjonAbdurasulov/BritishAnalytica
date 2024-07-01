using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.AboutBusinessModelRepository;
using Entity.Models.AboutBusinessModel;
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

    public AboutBusinessModelController(IAboutBusinessModelRepository aboutBusinessModelRepository)
    {
        AboutBusinessModelRepository = aboutBusinessModelRepository;
    }


    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( AboutBusinessDto dto)
    {
        var aboutBusiness = new AboutBusinessModel
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body,
            Futures = dto.Futures,
            ImageId = dto.ImageId,
            Name = dto.Name
        };
         await AboutBusinessModelRepository.AddAsync(aboutBusiness);
        return new ResponseModelBase(dto);
    } 
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( AboutBusinessDto dto)
    {
        var res = await AboutBusinessModelRepository.FirstOrDefaultAsync();
        res.Body = dto.Body;
        res.Futures = dto.Futures;
        res.Title = dto.Title;
        res.ImageId = dto.ImageId;
        res.UpdatedAt=DateTime.Now;
        res.Name = dto.Name;
        await AboutBusinessModelRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var res =  await AboutBusinessModelRepository.FirstOrDefaultAsync();
        await AboutBusinessModelRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync()
    {
        var res = await AboutBusinessModelRepository.FirstOrDefaultAsync();

        var dto = new AboutBusinessDto
        {
            Title = res.Title,
            Body = res.Body,
            Name=res.Name,
            Futures = res.Futures.ToList(),
            ImageId = res.ImageId
        };
        return new ResponseModelBase(dto);
    }
}