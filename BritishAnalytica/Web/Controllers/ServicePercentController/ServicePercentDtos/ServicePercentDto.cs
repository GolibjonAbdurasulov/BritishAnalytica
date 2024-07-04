
using Entity.Models.Common;

namespace Web.Controllers.ServicePercentController.ServicePercentDtos;

public class ServicePercentDto
{
    public long Id { get; set; }
    public MultiLanguageField ServiceName { get; set; }
    public float ServicePerecnt { get; set; }

}