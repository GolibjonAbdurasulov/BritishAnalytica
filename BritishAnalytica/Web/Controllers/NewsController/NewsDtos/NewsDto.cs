
using Entity.Models.Common;

namespace Web.Controllers.NewsController.NewsDtos;

public class NewsDto
{
    public MultiLanguageField Name { get; set; }
    public string Category { get; set; }
    public Guid ImageId { get; set; }
    public string PostTitle { get; set; }
    public string PostBody { get; set; }
    public DateTime PostedDate { get; set; }
}