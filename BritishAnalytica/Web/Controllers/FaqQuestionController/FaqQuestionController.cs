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
            Answer = dto.Answer,
            Question = dto.Question
        };
        var resEntity=await FaqQuestionRepository.AddAsync(entity);
        
        var resDto = new FaqQuestionDto
        {
            Id = resEntity.Id, 
            Answer = dto.Answer,
            Question = dto.Question
        };
        return new ResponseModelBase(resDto);
    }


  
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync( FaqQuestionDto dto)
    {
        var res =  await FaqQuestionRepository.GetByIdAsync(dto.Id);
        res.Answer = dto.Answer;
        res.Question=dto.Question;
      
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
            Answer = res.Answer,
            Question = res.Question
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
                Answer = question.Answer,
                Question = question.Question
            });
        }
        
        return new ResponseModelBase(dtos);
    }
}