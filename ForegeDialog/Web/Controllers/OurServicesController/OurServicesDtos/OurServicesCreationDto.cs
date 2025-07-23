using Entity.Models.Common;

namespace Web.Controllers.OurServicesController.OurServicesDtos;

public class OurServicesCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Description { get; set; }
}