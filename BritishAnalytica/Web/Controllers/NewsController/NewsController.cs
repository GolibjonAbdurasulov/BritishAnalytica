using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Extensions;
using DatabaseBroker.Repositories.NewsRepository;
using Entity.Models.Common;
using Entity.Models.News;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.NewsController.NewsDtos;

namespace Web.Controllers.NewsController;

[ApiController]
[Route("[controller]/[action]")]
public class NewsController : ControllerBase
{
    private INewsRepository NewsRepository { get; set; }

    public NewsController(INewsRepository newsRepository)
    {
        NewsRepository = newsRepository;
    }

    [HttpPost]
    public async Task<ResponseModelBase> CreateAsync(NewsDto dto)
    {
        var entity = new News
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Category = dto.Category,
            ImageId = dto.ImageId,
            PostTitle = dto.PostTitle,
            PostBody = dto.PostBody,
            PostedDate = dto.PostedDate,
            Name = dto.Name
        };
        await NewsRepository.AddAsync(entity);
        return new ResponseModelBase(dto);
    }

    [HttpPut]
    public async Task<ResponseModelBase> UpdateAsync(NewsDto dto, long id)
    {
        var res = await NewsRepository.GetByIdAsync(id);
        res.Category = dto.Category;
        res.ImageId = dto.ImageId;
        res.PostBody = dto.PostBody;
        res.PostTitle = dto.PostTitle;
        res.UpdatedAt = DateTime.Now;
        res.Name = dto.Name;

        await NewsRepository.UpdateAsync(res);
        return new ResponseModelBase(dto);
    }
    
    [HttpDelete]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = NewsRepository.FirstOrDefault();
        await NewsRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res = NewsRepository.LastOrDefault();
        var dto = new NewsDto
        {
            Category = res.Category,
            ImageId = res.ImageId,
            PostTitle = res.PostTitle,
            PostBody = res.PostBody,
            PostedDate = res.PostedDate,
            Name = res.Name
        };
        
        return new ResponseModelBase(dto);
    }
    [HttpGet]
    public async Task<ResponseModelBase> GetByPaginatonAsync(long id)
    {
        var res = NewsRepository.LastOrDefault();
        var dto = new NewsDto
        {
            Category = res.Category,
            ImageId = res.ImageId,
            PostTitle = res.PostTitle,
            PostBody = res.PostBody,
            PostedDate = res.PostedDate,
            Name = res.Name
        };
        NewsRepository.Paging(new TermModelBase
        {
            FilteringExpressions = null,
            FilterPropName = null,
            FilterPropValue = null,
            Skip = 5,
            Take = 5,
            SortPropName = null,
            SortDirection = null,
            Total = 0
        });
        return new ResponseModelBase(dto);
    }
}