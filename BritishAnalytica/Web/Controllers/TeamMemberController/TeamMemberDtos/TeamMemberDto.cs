
using Entity.Models.Common;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class TeamMemberDto
{
    public MultiLanguageField Name { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public Guid ImageId { get; set; }
}