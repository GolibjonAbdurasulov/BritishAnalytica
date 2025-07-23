using Entity.Models.Common;

namespace Web.Controllers.OurResourcesController.OurResourcesDtos;

public class OurResourcesDto
{
    public long Id { get; set; }
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Description { get; set; }
    public string FilePath { get; set; }
}