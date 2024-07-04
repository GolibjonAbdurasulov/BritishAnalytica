
using Entity.Models.Common;

namespace Web.Controllers.PpsController.PpsDtos;

public class SuccessDto
{
    public long Id { get; set; }
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
}