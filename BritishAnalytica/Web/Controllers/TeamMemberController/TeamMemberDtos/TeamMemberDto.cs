using System;

namespace Web.Controllers.TeamMemberController.TeamMemberDtos;

public class TeamMemberDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    public Guid ImageId { get; set; }
}