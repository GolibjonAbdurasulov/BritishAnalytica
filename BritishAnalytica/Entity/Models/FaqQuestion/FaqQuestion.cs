using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("service_percent")]
public class FaqQuestions : AuditableModelBase<long>
{
    [Column("body")]public string Body { get; set; }
    [Column("text")]public string Text { get; set; }
}