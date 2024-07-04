using Entity.Models.Common;

namespace Web.Controllers.ContactController.ContactDtos;

public class PhoneNumberCreationDto
{
    public MultiLanguageField Name { get; set; }
    public string Number { get; set; }
    public string WorkingTimeStart { get; set; }
    public string WorkingTimeStop { get; set; }
    public string WorkingDayStart { get; set; }
    public string WorkingDayStop { get; set; }
}