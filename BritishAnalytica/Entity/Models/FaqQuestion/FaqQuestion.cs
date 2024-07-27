using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.FaqQuestion;
[Table("faq_questions")]
public class FaqQuestions : AuditableModelBase<long>
{
    [Column("question", TypeName = "jsonb")]public MultiLanguageField Question { get; set; }
    [Column("answer", TypeName = "jsonb")]public MultiLanguageField Answer { get; set; }
}