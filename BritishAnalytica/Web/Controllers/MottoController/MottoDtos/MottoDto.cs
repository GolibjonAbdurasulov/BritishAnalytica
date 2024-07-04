
using Entity.Models.Common;

namespace Web.Controllers.MottoController.MottoDtos;

public class MottoDto
{
   public long Id { get; set; }
   public string Author { get; set; }
   public MultiLanguageField Text { get; set; }

}