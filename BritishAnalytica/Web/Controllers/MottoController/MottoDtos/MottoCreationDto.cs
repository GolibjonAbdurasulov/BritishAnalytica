using Entity.Models.Common;

namespace Web.Controllers.MottoController.MottoDtos;

public class MottoCreationDto
{
    public string Author { get; set; }
    public MultiLanguageField Text { get; set; }
}