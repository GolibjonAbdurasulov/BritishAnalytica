using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Skill;
[Table("skills")]
public class Skill : ModelBase<long>
{
    [Column("text", TypeName = "jsonb")]public MultiLanguageField Text { get; set; }
}