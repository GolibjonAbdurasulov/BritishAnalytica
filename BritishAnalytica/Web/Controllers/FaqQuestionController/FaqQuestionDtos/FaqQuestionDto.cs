
using Entity.Models.Common;

namespace Web.Controllers.FaqQuestionController.FaqQuestionDtos;

public class FaqQuestionDto
{
    public long Id { get; set; }
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
}