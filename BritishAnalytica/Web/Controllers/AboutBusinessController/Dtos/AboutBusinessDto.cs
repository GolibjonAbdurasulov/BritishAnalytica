
using Entity.Models.FutureModel;
using MultiLanguageField = Entity.Models.Common.MultiLanguageField;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class AboutBusinessDto
{
   public long Id { get; set; }
   public MultiLanguageField Title { get; set; }
   public MultiLanguageField About { get; set; }
   public MultiLanguageField MiniTitle { get; set; }
   public List<ReasonDto> ReasonDtos { get; set; }
   public Guid ImageId { get; set; }
}