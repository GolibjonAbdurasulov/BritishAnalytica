using Entity.Models.Common;

namespace Web.Controllers.AboutBusinessController.Dtos;

public class AboutBusinessCreationDto
{
    public MultiLanguageField Title { get; set; }
    public MultiLanguageField Body { get; set; }
    public List<FutureCreationDto> Futures { get; set; }
    public Guid ImageId { get; set; }
}