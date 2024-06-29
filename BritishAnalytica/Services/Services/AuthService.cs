using System;
using System.Linq;
using System.Threading.Tasks;
using DatabaseBroker.Repositories.UserRepository;
using Entity.Attributes;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services;
[Injectable]
public class AuthService : IAuthService
{
    public AuthService(IUserRepository repository)
    {
        Repository = repository;
    }

    private  IUserRepository Repository { get; set; }
    
    
    public async Task<UserDto> Login(UserLoginDto dto)
    {
        var user = await Repository.FirstOrDefaultAsync(user => user.Email == dto.Email && user.Password == dto.Password);
        if (user is  null)
            throw new NullReferenceException();
        
        return new UserDto
        {
            Email = user.Email,
            Password = user.Password,
            Role = user.Role.ToString()
        };
    }
}