using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Dtos;

namespace Services.Interfaces;

public interface IUserService
{
    public Task<ChangeUserRoleDto> ChangeUserRole(ChangeUserRoleDto dto);
    public  Task<UserEmailUpdateDto> UpdateUserEmail(UserEmailUpdateDto dto);
    public Task<UserPasswordUpdateDto> UpdateUserPassword(UserPasswordUpdateDto dto);
    public  Task<long> DeleteAsync(long id);
    public Task<UserGetDto> GetByIdAsync(long id);
    public  Task<UserDto> CreateAsync(UserCreationDto dto);
    public  Task<List<UserDto>> GetAllUsers();
}