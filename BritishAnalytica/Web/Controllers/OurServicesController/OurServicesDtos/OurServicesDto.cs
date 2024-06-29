using System;

namespace Web.Controllers.OurServicesController.OurServicesDtos;

public class OurServicesDto
{
   public string ServiceName { get; set; }
   public string AboutService { get; set; }
   public Guid ServiceIconId { get; set; }
}