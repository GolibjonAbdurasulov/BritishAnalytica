using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.TeamMember;
[Table("team_members")]
public class TeamMember : AuditableModelBase<long>
{
    [Column("name", TypeName = "jsonb")] public MultiLanguageField Name { get; set; } = default!;
    [Column("full_name")]public string FullName { get; set; }
    [Column("role")]public string Role { get; set; }
    [Column("image_id")]public Guid ImageId { get; set; }
}