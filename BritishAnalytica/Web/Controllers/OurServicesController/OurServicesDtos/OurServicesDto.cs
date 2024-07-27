
using Entity.Models.Common;

namespace Web.Controllers.OurServicesController.OurServicesDtos;

public class OurServicesDto
{
   public long Id { get; set; }
   public MultiLanguageField ServiceName { get; set; }
   public MultiLanguageField AboutService { get; set; }
}