
using Entity.Models.FutureModel;
using MultiLanguageField = Entity.Models.Common.MultiLanguageField;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class AboutBusinessDto
{
   public long Id { get; set; }
   public MultiLanguageField Title { get; set; }
   public MultiLanguageField Body { get; set; }
   public List<FutureDto> Futures { get; set; }
   public Guid ImageId { get; set; }
}