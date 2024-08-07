
using Entity.Models.Common;
using Entity.Models.Skills;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class TeamMemberDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public MultiLanguageField Role { get; set; }
    public List<Skill> Skills { get; set; }
    public Guid ImageId { get; set; }
}