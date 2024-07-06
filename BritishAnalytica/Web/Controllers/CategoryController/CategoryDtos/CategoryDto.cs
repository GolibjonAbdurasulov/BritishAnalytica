using Entity.Models.Common;

namespace Web.Controllers.CategoryController.CategoryDtos;

public class CategoryDto
{
    public long Id { get; set; }
    public MultiLanguageField CategoryName { get; set; }
}