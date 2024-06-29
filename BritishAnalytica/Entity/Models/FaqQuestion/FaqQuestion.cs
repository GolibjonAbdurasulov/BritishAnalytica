using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("service_percent")]
public class FaqQuestions : AuditableModelBase<long>
{
    [Column("title")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
}