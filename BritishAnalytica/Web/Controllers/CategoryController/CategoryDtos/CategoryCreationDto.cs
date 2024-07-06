using Entity.Models.Common;

namespace Web.Controllers.CategoryController.CategoryDtos;

public class CategoryCreationDto
{
    public MultiLanguageField CategoryName { get; set; }
}