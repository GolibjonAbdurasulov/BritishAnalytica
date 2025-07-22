using Entity.Models.Common;

namespace Web.Controllers.FaqQuestionController.FaqQuestionDtos;

public class FaqQuestionCreationDto
{
    public MultiLanguageField Answer { get; set; }
    public MultiLanguageField Question { get; set; }
}