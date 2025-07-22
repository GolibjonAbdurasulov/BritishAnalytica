
using Entity.Models.Common;

namespace Web.Controllers.FaqQuestionController.FaqQuestionDtos;

public class FaqQuestionDto
{
    public long Id { get; set; }
    public MultiLanguageField Answer { get; set; }
    public MultiLanguageField Question { get; set; }
}