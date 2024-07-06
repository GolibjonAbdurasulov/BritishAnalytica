namespace Services.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool IsSigned { get; set; }
    public string Token { get; set; }
}