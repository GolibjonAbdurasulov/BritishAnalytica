using Entity.Models.Common;

namespace Web.Controllers.NewsController.NewsDtos;

public class NewsCreationDto
{
    public long Category { get; set; }
    public Guid ImageId { get; set; }
    public MultiLanguageField PostTitle { get; set; }
    public MultiLanguageField PostBody { get; set; }
    public DateTime PostedDate { get; set; }
}