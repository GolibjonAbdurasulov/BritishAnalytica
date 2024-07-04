using Entity.Models.Common;

namespace Web.Controllers.PpsController.PpsDtos;

public class SuccessCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
}