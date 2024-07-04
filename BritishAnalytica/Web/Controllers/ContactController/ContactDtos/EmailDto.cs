
using Entity.Models.Common;

namespace Web.Controllers.ContactController.ContactDtos;

public class EmailDto
{
   public long Id { get; set; }
   public MultiLanguageField Name { get; set; }
   public string EmailAddress { get; set; }
   public string Web { get; set; }
}