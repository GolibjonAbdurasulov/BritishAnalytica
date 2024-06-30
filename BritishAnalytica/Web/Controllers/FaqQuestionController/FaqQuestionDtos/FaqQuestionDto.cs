
using Entity.Models.Common;

namespace Web.Controllers.FaqQuestionController.FaqQuestionDtos;

public class FaqQuestionDto
{
    public MultiLanguageField Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}