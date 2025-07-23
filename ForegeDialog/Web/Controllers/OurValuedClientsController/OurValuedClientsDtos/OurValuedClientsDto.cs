using Entity.Models.Common;

namespace Web.Controllers.OurValuedClientsController.OurValuedClientsDtos;

public class OurValuedClientsDto
{
    public long Id { get; set; }
    public MultiLanguageField CompanyName { get; set; }
    public string  ImagePath { get; set; }
    public string  link { get; set; }
}