
using Entity.Models.Common;

namespace Web.Controllers.PpsController.PpsDtos;

public class ProjectDto
{
    public MultiLanguageField Name { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}