using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("service_percent")]
public class FaqQuestion : AuditableModelBase<long>
{
    [Column("body")]public string Body { get; set; }
    [Column("text")]public string Text { get; set; }
}