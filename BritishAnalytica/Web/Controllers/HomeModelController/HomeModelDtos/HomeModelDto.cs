
using Entity.Models.Common;

namespace Web.Controllers.HomeModelController.HomeModelDtos;

public class HomeModelDto
{
   public MultiLanguageField Name { get; set; }
   public string Title { get; set; }
   public string Body { get; set; }
   public List<Guid> ImageIds { get; set; }
}