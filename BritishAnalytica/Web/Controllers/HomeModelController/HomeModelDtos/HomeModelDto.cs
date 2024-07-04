
using Entity.Models.Common;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelDto
{
   public long Id { get; set; }
   public MultiLanguageField Title { get; set; }
   public MultiLanguageField Body { get; set; }
   public List<Guid> ImageIds { get; set; }
}