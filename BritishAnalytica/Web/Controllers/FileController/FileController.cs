using DatabaseBroker.Repositories.FaqQuestionsRepository;
using DatabaseBroker.Repositories.FileRepository;
using Entity.Models.FaqQuestion;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.FaqQuestionController.FaqQuestionDtos;

namespace Web.Controllers.FileController;

[ApiController]
[Route("[controller]/[action]")]
public class FileController : ControllerBase
{
    private IFileRepository FileRepository { get; set; }

    public FileController(IFileRepository fileRepository)
    {
        FileRepository = fileRepository;
    }


    // [HttpPost]
    // public async Task<ResponseModelBase> CreateAsync( FaqQuestionDto dto)
    // {
    //     var entity = new FaqQuestions
    //     {
    //         CreatedAt = DateTime.Now,
    //         UpdatedAt = DateTime.Now,
    //         Title = dto.Title,
    //         Body = dto.Body
    //     };
    //     await FileRepository.AddAsync(entity);
    //     return new ResponseModelBase(dto);
    // }
    //
    //
    //
    // [HttpPut]
    // public async Task<ResponseModelBase> UpdateAsync( FaqQuestionDto dto,long id)
    // {
    //     var res =  await FileRepository.GetByIdAsync(id);
    //     res.Body = dto.Body;
    //     res.Title=dto.Title;
    //     
    //     await FileRepository.UpdateAsync(res);
    //     return new ResponseModelBase(dto);
    // }
    //
    //
    // [HttpDelete]
    // public async Task<ResponseModelBase> DeleteAsync()
    // {
    //     var res =  FileRepository.LastOrDefault();
    //     await FileRepository.RemoveAsync(res);
    //     return new ResponseModelBase(res);
    // }
    //
    // [HttpGet]
    // public async Task<ResponseModelBase> GetByIdAsync(long id)
    // {
    //     var res =  await FileRepository.GetByIdAsync(id);
    //     var dto = new FaqQuestionDto
    //     {
    //         Title = res.Title,
    //         Body = res.Body
    //     };
    //     return new ResponseModelBase(dto);
    // }
    //
    // [HttpGet]
    // public async Task<ResponseModelBase> GetAllAsync()
    // {
    //     var res =   FileRepository.GetAllAsQueryable().ToList();
    //     List<FaqQuestionDto> dtos = new List<FaqQuestionDto>();
    //     foreach (FaqQuestions question in res)
    //     {
    //         dtos.Add(new FaqQuestionDto
    //         {
    //             Title = question.Title,
    //             Body = question.Body
    //         });
    //     }
    //     
    //     return new ResponseModelBase(dtos);
    // }
    //
}