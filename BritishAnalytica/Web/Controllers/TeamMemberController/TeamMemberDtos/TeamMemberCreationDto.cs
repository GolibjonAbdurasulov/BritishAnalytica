using Entity.Models.Common;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class TeamMemberCreationDto
{
    public string FullName { get; set; }
    public MultiLanguageField Role { get; set; }
    public Guid ImageId { get; set; }
}