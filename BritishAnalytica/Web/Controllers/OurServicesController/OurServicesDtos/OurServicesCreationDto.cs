using Entity.Models.Common;

namespace Web.Controllers.OurServicesController.OurServicesDtos;

public class OurServicesCreationDto
{
    public MultiLanguageField ServiceName { get; set; }
    public MultiLanguageField AboutService { get; set; }
    public Guid ServiceIconId { get; set; }
}