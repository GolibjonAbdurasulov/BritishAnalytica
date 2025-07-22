using Entity.Models.Common;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class SkillDto
{
    public long Id { get; set; }
    public MultiLanguageField Text { get; set; }
}