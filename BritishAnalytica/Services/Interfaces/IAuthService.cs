using System.Threading.Tasks;
using Services.Dtos;

namespace Services.Interfaces;

public interface IAuthService
{
    public Task<UserLoginedDto> Login(UserLoginDto dto);
    public  Task<bool> LogOut(long id);
    public Task<UserDto> GetUser(long id);
}