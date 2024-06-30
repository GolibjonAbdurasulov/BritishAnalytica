
using Entity.Models.Common;

namespace Web.Controllers.OurServicesController.OurServicesDtos;

public class OurServicesDto
{
   public MultiLanguageField Name { get; set; }
   public string ServiceName { get; set; }
   public string AboutService { get; set; }
   public Guid ServiceIconId { get; set; }
}