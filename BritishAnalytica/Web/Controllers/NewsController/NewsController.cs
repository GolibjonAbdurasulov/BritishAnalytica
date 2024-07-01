using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Extensions;
using DatabaseBroker.Repositories.NewsRepository;
using Entity.Models.Common;
using Entity.Models.News;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =await NewsRepository.GetByIdAsync(id);
        await NewsRepository.RemoveAsync(res);
        return new ResponseModelBase(res);
    }

    [HttpGet]
    public async Task<ResponseModelBase> GetByIdAsync(long id)
    {
        var res =await NewsRepository.GetByIdAsync(id);
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
    public async Task<ResponseModelBase> GetAllAsync(long id)
    {
        var res = NewsRepository.GetAllAsQueryable().ToList();
        List<NewsDto> news = new List<NewsDto>();

        foreach (News newsDto in res)
        {
            var dto = new NewsDto
            {
                Category = newsDto.Category,
                ImageId = newsDto.ImageId,
                PostTitle = newsDto.PostTitle,
                PostBody = newsDto.PostBody,
                PostedDate = newsDto.PostedDate,
                Name = newsDto.Name
            };
            news.Add(dto);
        }

        return new ResponseModelBase(news);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetByPaginatonAsync(long id, int pageNumber = 1, int pageSize = 5)
    {
        // Yangiliklarni bazadan olish
        var newsList =  NewsRepository.GetAllAsQueryable().ToList();

        // Paging sozlamalari
        var pagedNews = newsList
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // DTO yaratish
        var dtoList = pagedNews.Select(res => new NewsDto
        {
            Category = res.Category,
            ImageId = res.ImageId,
            PostTitle = res.PostTitle,
            PostBody = res.PostBody,
            PostedDate = res.PostedDate,
            Name = res.Name
        }).ToList();

        // Umumiy yangiliklar soni
        int totalNews = newsList.Count();

        // Paging natijalarini qaytarish
        var result = new ResponseModelBase(new PagedResult<NewsDto>
        {
            Items = dtoList,
            TotalCount = totalNews,
            PageNumber = pageNumber,
            PageSize = pageSize
        });

        return result;
    }

}