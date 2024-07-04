using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("faq_questions")]
public class FaqQuestions : AuditableModelBase<long>
{
    [Column("title", TypeName = "jsonb")]public MultiLanguageField Title { get; set; }
    [Column("body", TypeName = "jsonb")]public MultiLanguageField Body { get; set; }
}