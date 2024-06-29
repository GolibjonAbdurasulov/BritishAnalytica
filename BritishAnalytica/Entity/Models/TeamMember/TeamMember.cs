using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.TeamMember;
[Table("team_member")]
public class TeamMember : AuditableModelBase<long>
{
    [Column("name")]public string Name { get; set; }
    [Column("role")]public string Role { get; set; }
    [Column("image_id")]public Guid ImageId { get; set; }
}