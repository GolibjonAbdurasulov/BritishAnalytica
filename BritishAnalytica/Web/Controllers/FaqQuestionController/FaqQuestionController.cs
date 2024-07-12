using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.FaqQuestionsRepository;
using Entity.Models.FaqQuestion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Common;
using Web.Controllers.FaqQuestionController.FaqQuestionDtos;

namespace Web.Controllers.FaqQuestionController;

[ApiController]
[Route("[controller]/[action]")]
public class FaqQuestionController : ControllerBase
{
    private IFaqQuestionRepository FaqQuestionRepository { get; set; }

    public FaqQuestionController(IFaqQuestionRepository faqQuestionRepository)
    {
        FaqQuestionRepository = faqQuestionRepository;
    }


    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( FaqQuestionCreationDto dto)
    {
        var entity = new FaqQuestions
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body
        };
        var resEntity=await FaqQuestionRepository.AddAsync(entity);
        
        var resDto = new FaqQuestionDto
        {
            Id = resEntity.Id, 
            Title = resEntity.Title,
            Body = resEntity.Body
        };
        return new ResponseModelBase(resDto);
    }


  
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( FaqQuestionDto dto)
    {
        var res =  await FaqQuestionRepository.GetByIdAsync(dto.Id);
        res.Body = dto.Body;
        res.Title=dto.Title;
      
        res.UpdatedAt=DateTime.Now;
        await FaqQuestionRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        
        var res =  await FaqQuestionRepository.GetByIdAsync(id);
        await FaqQuestionRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await FaqQuestionRepository.GetByIdAsync(id);
        var dto = new FaqQuestionDto
        {
            Id = res.Id,
            Title = res.Title,
            Body = res.Body
        };
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res =   FaqQuestionRepository.GetAllAsQueryable().ToList();
        List<FaqQuestionDto> dtos = new List<FaqQuestionDto>();
        foreach (FaqQuestions question in res)
        {
            dtos.Add(new FaqQuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                Body = question.Body
            });
        }
        
        return new ResponseModelBase(dtos);
    }
}