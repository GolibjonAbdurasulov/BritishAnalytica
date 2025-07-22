using Entity.Models.Common;

namespace Web.Controllers.OurValuesController.OurValueDtos;

public class OurValueDto
{
    public long Id { get; set; }
    public MultiLanguageField ValueName { get; set; }
    public MultiLanguageField AboutValue { get; set; }
}