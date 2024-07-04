using Entity.Models.Common;

namespace Web.Controllers.ContactController.ContactDtos;

public class ContactCreationDto
{
    public MultiLanguageField Name { get; set; }
    public EmailCreationDto EmailDto { get; set; }
    public PhoneNumberCreationDto PhoneNumberDto { get; set; }
    public LocationCreationDto LocationDto { get; set; }
}