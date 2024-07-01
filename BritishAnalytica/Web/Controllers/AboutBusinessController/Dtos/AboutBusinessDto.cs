
using MultiLanguageField = Entity.Models.Common.MultiLanguageField;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class AboutBusinessDto
{
   public string Title { get; set; }
   public string Body { get; set; }
   public List<string> Futures { get; set; }
   public Guid ImageId { get; set; }
   public MultiLanguageField Name { get; set; }
}