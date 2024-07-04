using Entity.Models.Common;

namespace Web.Controllers.FaqQuestionController.FaqQuestionDtos;

public class FaqQuestionCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
}