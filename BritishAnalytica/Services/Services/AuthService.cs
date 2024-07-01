using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DatabaseBroker.Repositories.UserRepository;
using Entity.Attributes;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services;
[Injectable]
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IUserRepository repository, IConfiguration configuration)
    {
        Repository = repository;
        _configuration = configuration;
    }

    private  IUserRepository Repository { get; set; }
    
    
    public async Task<UserLoginedDto> Login(UserLoginDto dto)
    {
        var user = await Repository.FirstOrDefaultAsync(user => user.Email == dto.Email && user.Password == dto.Password);
        if (user is  null)
            throw new NullReferenceException();
       
        var resUser = new UserLoginedDto()
        {
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role.ToString()
        };

        user.IsSigned = true;
        await Repository.UpdateAsync(user);
        return resUser;
    }
   
    public async Task<bool> LogOut(long id)
    {
        var user = await Repository.GetByIdAsync(id);
        if (user is  null)
            throw new NullReferenceException();
        
        user.IsSigned = false;
        await Repository.UpdateAsync(user);
        return true;
    }
    
    public async Task<UserDto> GetUser(long id)
    {
        var user=await Repository.GetByIdAsync(id);
        return new UserDto
        {
            UserName=user.UserName,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role.ToString()
        };
    }
    
    

}