using Entity.Models.Common;

namespace Web.Controllers.OurValuedClientsController.OurValuedClientsDtos;

public class OurValuedClientsCreationDto
{
    public MultiLanguageField CompanyName { get; set; }
    public string  ImagePath { get; set; }
    public string  link { get; set; }
}