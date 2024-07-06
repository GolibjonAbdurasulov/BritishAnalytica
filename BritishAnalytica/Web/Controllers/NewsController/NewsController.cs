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
    public async Task<ResponseModelBase> CreateAsync(NewsCreationDto dto)
    {
        var entity = new News
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            CategoryId = dto.Category,
            ImageId = dto.ImageId,
            PostTitle = dto.PostTitle,
            PostBody = dto.PostBody,
            PostedDate = dto.PostedDate
        };
        var resEntity=await NewsRepository.AddAsync(entity);
        var newsDto = new NewsDto
        {
            Id = resEntity.Id,
            CategoryId = resEntity.CategoryId,
            ImageId = resEntity.ImageId,
            PostTitle = resEntity.PostTitle,
            PostBody = resEntity.PostBody,
            PostedDate = resEntity.PostedDate
        };
        return new ResponseModelBase(newsDto);
    }

    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(NewsDto dto)
    {
        var res = await NewsRepository.GetByIdAsync(dto.Id);
        res.Category.Id = dto.CategoryId;
        res.ImageId = dto.ImageId;
        res.PostBody = dto.PostBody;
        res.PostTitle = dto.PostTitle;
        res.UpdatedAt = DateTime.Now;

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
            CategoryId = res.CategoryId,
            ImageId = res.ImageId,
            PostTitle = res.PostTitle,
            PostBody = res.PostBody,
            PostedDate = res.PostedDate
        };
        
        return new ResponseModelBase(dto);
    }
    
    [HttpGet]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res = NewsRepository.GetAllAsQueryable().ToList();
        List<NewsDto> news = new List<NewsDto>();

        foreach (News newsDto in res)
        {
            var dto = new NewsDto
            {
                CategoryId = newsDto.CategoryId,
                ImageId = newsDto.ImageId,
                PostTitle = newsDto.PostTitle,
                PostBody = newsDto.PostBody,
                PostedDate = newsDto.PostedDate
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
            CategoryId = res.CategoryId,
            ImageId = res.ImageId,
            PostTitle = res.PostTitle,
            PostBody = res.PostBody,
            PostedDate = res.PostedDate
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