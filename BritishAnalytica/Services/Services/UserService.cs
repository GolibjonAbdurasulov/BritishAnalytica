using System;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.UserRepository;
using Entity.Attributes;
using Entity.Enums;
using Entity.Models.Users;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services;
[Injectable]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    
    
    public async Task<UserGetDto> GetByIdAsync(long id)
    {
        var oldUser = await _userRepository.GetByIdAsync(id);
        var dto = new UserGetDto
        {
            UserName=oldUser.UserName,
            Email = oldUser.Email,
            Password = oldUser.Password,
            Role = oldUser.Role.ToString(),
            IsSigned = oldUser.IsSigned
            
            
        };
        return dto;
    }
    public async Task<long> DeleteAsync(long id)
    {
        var oldUser = await _userRepository.GetByIdAsync(id); 
        await _userRepository.RemoveAsync(oldUser);
        return id;
    }
    public async Task<ChangeUserRoleDto> ChangeUserRole(ChangeUserRoleDto dto)
    {
        var oldUser = await _userRepository.GetByIdAsync(dto.UserId);
        oldUser.Role = Enum.Parse<Role>(dto.Role);
        await _userRepository.UpdateAsync(oldUser);
        return dto;
    }

    public async Task<UserEmailUpdateDto> UpdateUserEmail(UserEmailUpdateDto dto)
    {
        var oldUser = await _userRepository.GetByIdAsync(dto.Id);
        oldUser.Email = dto.Email;
        await _userRepository.UpdateAsync(oldUser);
        return dto;
    }
    public async Task<UserDto> CreateAsync(UserCreationDto dto)
    {
        var user = new User
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserName=dto.UserName,
            Email = dto.Email,
            Password = dto.Password,
            Role = Enum.Parse<Role>(dto.Role),
            IsSigned = false
        };
        var resDto = new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role.ToString(),
            IsSigned = user.IsSigned
        };
        await _userRepository.AddAsync(user);
        return resDto;
    }
    public async Task<UserPasswordUpdateDto> UpdateUserPassword(UserPasswordUpdateDto dto)
    {
        var oldUser = await _userRepository.GetByIdAsync(dto.Id);
        oldUser.Password = dto.Password;
        await _userRepository.UpdateAsync(oldUser);
        return dto;
    }


    
}