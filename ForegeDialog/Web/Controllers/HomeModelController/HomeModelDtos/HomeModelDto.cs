
using Entity.Models.Common;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelDto
{
   public long Id { get; set; }
   public MultiLanguageField Text { get; set; }
   public Guid ImageId { get; set; }
}