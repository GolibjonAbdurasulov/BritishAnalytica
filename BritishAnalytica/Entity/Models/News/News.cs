using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.News;
[Table("news")]
public class News : AuditableModelBase<long>
{
    [Column("category", TypeName = "jsonb")] public MultiLanguageField Category { get; set; }
    [Column("image_id")] public Guid ImageId { get; set; }
    [Column("post_title", TypeName = "jsonb")] public MultiLanguageField PostTitle { get; set; }
    [Column("post_body", TypeName = "jsonb")] public MultiLanguageField PostBody { get; set; }
    [Column("posted_date")] public DateTime PostedDate { get; set; }
}