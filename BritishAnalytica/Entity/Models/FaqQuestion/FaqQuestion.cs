using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("faq_questions",Schema = "british_analytica")]
public class FaqQuestions : AuditableModelBase<long>
{
    [Column("title")]public string Title { get; set; }
    [Column("body")]public string Body { get; set; }
}