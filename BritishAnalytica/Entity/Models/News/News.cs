using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.CategoryModel;
using Entity.Models.Common;

namespace Entity.Models.News;
[Table("news")]
public class News : AuditableModelBase<long>
{
    [Column("image_id")] public Guid ImageId { get; set; }
    [Column("post_title", TypeName = "jsonb")] public MultiLanguageField PostTitle { get; set; }
    [Column("post_body", TypeName = "jsonb")] public MultiLanguageField PostBody { get; set; }
    [Column("posted_date")] public DateTime PostedDate { get; set; }
    [Column("category_id"),ForeignKey(nameof(Category))] public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
}