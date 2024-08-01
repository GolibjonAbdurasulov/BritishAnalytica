using Entity.Models.Common;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class AboutBusinessCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField About { get; set; }
    public MultiLanguageField MiniTitle { get; set; }
    public List<ReasonCreationDto> ReasonDtos { get; set; }
    public Guid ImageId { get; set; }
}