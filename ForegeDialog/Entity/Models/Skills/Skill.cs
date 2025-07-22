using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Newtonsoft.Json;

namespace Entity.Models.Skills;
[Table("skills")]
public class Skill : ModelBase<long>
{
    [Column("text", TypeName = "jsonb")]
    public MultiLanguageField Text { get; set; }
    
    [Column("team_member_id")]
    public long TeamMemberId { get; set; }

    [ForeignKey("TeamMemberId")]
    public virtual TeamMember.TeamMember TeamMember { get; set; }
}
