using Entity.Models.Common;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class FutureDto
{
    public long Id { get; set; }
    public MultiLanguageField Text { get; set; }
}