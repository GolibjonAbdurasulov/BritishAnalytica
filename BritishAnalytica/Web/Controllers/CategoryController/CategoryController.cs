using DatabaseBroker.Repositories.CategoryRepository;
using Entity.Models.CategoryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Web.Controllers.CategoryController.CategoryDtos;

namespace Web.Controllers.CategoryController;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private ICategoryRepository Repository { get; set; }

    public CategoryController(ICategoryRepository repository)
    {
        Repository = repository;
    }

    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync(CategoryCreationDto dto)
    {
        var entity = new Category
        {
            CategoryName = dto.CategoryName
        };
        var res = await Repository.AddAsync(entity);
        var resDto = new CategoryDto
        {
            Id = res.Id,
            CategoryName = res.CategoryName
        };
        return new ResponseModelBase(resDto);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateAsync(CategoryDto dto)
    {
        var entity = new Category
        {
            Id=dto.Id,
            CategoryName = dto.CategoryName
        };
        var res = await Repository.UpdateAsync(entity);
        var resDto = new CategoryDto
        {
            Id = res.Id,
            CategoryName = res.CategoryName
        };
        return new ResponseModelBase(resDto);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res = await Repository.GetByIdAsync(id);
        await Repository.RemoveAsync(res);
        
        var resDto = new CategoryDto
        {
            Id = res.Id,
            CategoryName = res.CategoryName
        };
        return new ResponseModelBase(resDto);
    }
    
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res =  Repository.GetAllAsQueryable().ToList();
        
        return new ResponseModelBase(res);
    }
    
    
    
}