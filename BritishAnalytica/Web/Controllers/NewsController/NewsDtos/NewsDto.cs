
using Entity.Models.Common;

namespace Web.Controllers.NewsController.NewsDtos;

public class NewsDto
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public Guid ImageId { get; set; }
    public MultiLanguageField PostTitle { get; set; }
    public MultiLanguageField PostBody { get; set; }
    public DateTime PostedDate { get; set; }
}