
using Entity.Models.Common;

namespace Web.Controllers.PpsController.PpsDtos;

public class PpsModelDto
{
    public long Id { get; set; }
    public PlaningDto PlaningDto { get; set; }
    public ProjectDto ProjectDto { get; set; }
    public SuccessDto SuccessDto { get; set; }
}