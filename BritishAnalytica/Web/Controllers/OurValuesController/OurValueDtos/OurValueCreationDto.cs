using Entity.Models.Common;

namespace Web.Controllers.OurValuesController.OurValueDtos;

public class OurValueCreationDto
{
    public MultiLanguageField ValueName { get; set; }
    public MultiLanguageField AboutValue { get; set; }
}