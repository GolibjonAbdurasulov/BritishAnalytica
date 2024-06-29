using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.FaqQuestionsRepository;
using Entity.Models.FaqQuestion;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ResponseModelBase> CreateAsync( FaqQuestionDto dto)
    {
        var entity = new FaqQuestions
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Title = dto.Title,
            Body = dto.Body
        };
        await FaqQuestionRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }


  
    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync( FaqQuestionDto dto,long id)
    {
        var res =  await FaqQuestionRepository.GetByIdAsync(id);
        res.Body = dto.Body;
        res.Title=dto.Title;
        
        await FaqQuestionRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync()
    {
        var res =  FaqQuestionRepository.LastOrDefault();
        await FaqQuestionRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =  await FaqQuestionRepository.GetByIdAsync(id);
        var dto = new FaqQuestionDto
        {
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
                Title = question.Title,
                Body = question.Body
            });
        }
        
        return new ResponseModelBase(dtos);
    }
}