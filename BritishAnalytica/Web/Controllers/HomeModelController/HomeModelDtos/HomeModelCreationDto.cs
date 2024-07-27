using Entity.Models.Common;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelCreationDto
{
    public MultiLanguageField Text { get; set; }
    public Guid ImageId { get; set; }
}