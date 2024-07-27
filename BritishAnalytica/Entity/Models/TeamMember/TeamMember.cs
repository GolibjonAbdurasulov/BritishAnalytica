using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.TeamMember;
[Table("team_members")]
public class TeamMember : AuditableModelBase<long>
{
    [Column("full_name", TypeName = "jsonb")]public string FullName { get; set; }
    [Column("role", TypeName = "jsonb")]public MultiLanguageField Role { get; set; }
    [Column("skills", TypeName = "jsonb")]public List<Skill.Skill> Skills { get; set; }
    [Column("image_id", TypeName = "jsonb")]public Guid ImageId { get; set; }
}