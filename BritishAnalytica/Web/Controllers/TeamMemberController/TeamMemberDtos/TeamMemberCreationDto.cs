using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;
using Entity.Models.Skills;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class TeamMemberCreationDto
{
    public string FullName { get; set; }
    public MultiLanguageField Role { get; set; }
    public List<Skill> Skills { get; set; }
    public Guid ImageId { get; set; }
}