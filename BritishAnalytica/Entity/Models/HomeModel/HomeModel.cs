using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.HomeModel;

[Table("home_model")]
public class HomeModel : AuditableModelBase<long>
{
    [Column("text")]public string Text { get; set; }
    [Column("body")]public string Body { get; set; }
    [Column("image_id")]public Guid ImageId { get; set; }
}