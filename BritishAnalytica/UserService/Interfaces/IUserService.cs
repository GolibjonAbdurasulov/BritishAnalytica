using UserService.Dtos;

namespace UserService.Interfaces;

public interface IUserService
{
    public Task<ChangeUserRoleDto> ChangeUserRole(ChangeUserRoleDto dto);
}