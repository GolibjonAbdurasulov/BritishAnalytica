using System.Threading.Tasks;
using Services.Dtos;

namespace Services.Interfaces;

public interface IAuthService
{
    public Task<UserDto> Login(UserLoginDto dto);
}