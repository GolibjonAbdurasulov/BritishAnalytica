
using Entity.Models.Common;

namespace Web.Controllers.ServicePercentController.ServicePercentDtos;

public class ServicePercentDto
{
    public MultiLanguageField Name { get; set; }
    public string ServiceName { get; set; }
    public string ServicePerecnt { get; set; }

}