namespace Services.Dtos;

public class UserGetDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool IsSigned { get; set; }
}