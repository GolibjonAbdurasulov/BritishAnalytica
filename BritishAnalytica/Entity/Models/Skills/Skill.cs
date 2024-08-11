using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Skills;
[Table("skills")]
public class Skill : ModelBase<long>
{
    [Column("text", TypeName = "jsonb")] public MultiLanguageField Text { get; set; }

    // Foreign key property
    public long TeamMemberId { get; set; }

    // Navigation property
    public virtual TeamMember.TeamMember TeamMember { get; set; }
}