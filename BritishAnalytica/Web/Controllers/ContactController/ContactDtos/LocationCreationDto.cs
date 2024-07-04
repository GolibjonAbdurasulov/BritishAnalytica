using Entity.Models.Common;

namespace Web.Controllers.ContactController.ContactDtos;

public class LocationCreationDto
{
    public MultiLanguageField Name { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Home { get; set; }
}