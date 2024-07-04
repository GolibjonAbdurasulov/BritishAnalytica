using Entity.Models.Common;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
    public List<Guid> ImageIds { get; set; }
}