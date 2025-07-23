using Entity.Models.Common;

namespace Web.Controllers.OurResourcesController.OurResourcesDtos;

public class OurResourcesCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Description { get; set; }
    public string FilePath { get; set; }
}