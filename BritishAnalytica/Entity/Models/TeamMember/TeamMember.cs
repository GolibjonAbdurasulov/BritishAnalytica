using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.Skills;

namespace Entity.Models.TeamMember;
[Table("team_members")]
public class TeamMember : AuditableModelBase<long>
{
    [Column("full_name")]
    public string FullName { get; set; }
    
    [Column("role", TypeName = "jsonb")]
    public MultiLanguageField Role { get; set; }
    
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    [Column("image_id")]
    public Guid ImageId { get; set; }
}
