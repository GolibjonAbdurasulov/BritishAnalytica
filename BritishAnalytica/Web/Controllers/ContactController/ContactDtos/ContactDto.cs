
using Entity.Models.Common;

namespace Web.Controllers.ContactController.ContactDtos;

public class ContactDto
{
    public long Id { get; set; }
    public MultiLanguageField Name { get; set; }
    public EmailDto EmailDto { get; set; }
    public PhoneNumberDto PhoneNumberDto { get; set; }
    public LocationDto LocationDto { get; set; }
}