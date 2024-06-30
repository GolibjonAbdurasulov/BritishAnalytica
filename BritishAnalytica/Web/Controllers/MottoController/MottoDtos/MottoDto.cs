
using Entity.Models.Common;

namespace Web.Controllers.MottoController.MottoDtos;

public class MottoDto
{
   public MultiLanguageField Name { get; set; }
   public string Author { get; set; }
   public string Text { get; set; }

}