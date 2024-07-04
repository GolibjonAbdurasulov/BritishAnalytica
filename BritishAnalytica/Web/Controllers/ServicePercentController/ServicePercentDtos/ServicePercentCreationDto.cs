using Entity.Models.Common;

namespace Web.Controllers.ServicePercentController.ServicePercentDtos;

public class ServicePercentCreationDto
{
    public MultiLanguageField ServiceName { get; set; }
    public float ServicePerecnt { get; set; }
}