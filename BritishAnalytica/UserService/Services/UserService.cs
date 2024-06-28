using DatabaseBroker.Repositories.UserRepository;
using Entity.Enums;
using UserService.Dtos;
using UserService.Interfaces;

namespace UserService.Services;

public class UserService : IUserService
{
    public IUserRepository UserRepository;

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<ChangeUserRoleDto> ChangeUserRole(ChangeUserRoleDto dto)
    {
        var oldUser = await UserRepository.GetByIdAsync(dto.UserId);
        oldUser.Role = Enum.Parse<Role>(dto.Role);
        await UserRepository.UpdateAsync(oldUser);
        return dto;
    }

    public async Task<UserEmailUpdateDto> UpdateUserEmail(UserEmailUpdateDto dto)
    {
        var oldUser = await UserRepository.GetByIdAsync(dto.Id);
        oldUser.Email = dto.Email;
        await UserRepository.UpdateAsync(oldUser);
        return dto;
    }
    public async Task<UserPasswordUpdateDto> UpdateUserPassword(UserPasswordUpdateDto dto)
    {
        var oldUser = await UserRepository.GetByIdAsync(dto.Id);
        oldUser.Password = dto.Password;
        await UserRepository.UpdateAsync(oldUser);
        return dto;
    }
}