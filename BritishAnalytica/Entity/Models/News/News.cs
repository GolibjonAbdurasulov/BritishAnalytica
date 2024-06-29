using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.News;
[Table("news")]
public class News : AuditableModelBase<long>
{
    [Column("category")] public string Category { get; set; }
    [Column("image_id")] public Guid ImageId { get; set; }
    [Column("post_title")] public string PostTitle { get; set; }
    [Column("post_body")] public string PostBody { get; set; }
    [Column("posted_date")] public DateTime PostedDate { get; set; }
}