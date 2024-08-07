using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DatabaseBroker.Repositories.UserRepository;
using Entity.Attributes;
using Entity.Models.Users;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using Services.Interfaces;

namespace Services.Services;
[Injectable]
public class AuthService : IAuthService
{
    private  IUserRepository Repository { get; set; }
    private readonly ITokenService _tokenService;
    public AuthService(IUserRepository repository, ITokenService tokenService)
    {
        Repository = repository;
        _tokenService = tokenService;
    }


    public async Task<UserDto> Login(UserLoginDto dto)
    {
        var user = await Repository.FirstOrDefaultAsync(user => user.Email == dto.Email && user.Password == dto.Password);
        if (user is  null)
            throw new NullReferenceException();
        string token =  _tokenService.GetToken();
        var resUser = new UserDto()
        {
            Id=user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role.ToString(),
            IsSigned = true,
            Token = token
        };

        user.IsSigned = true;
        await Repository.UpdateAsync(user);
        return resUser;
    }
   
    public async Task<bool> LogOut(long id)
    {
        var user =await Repository.GetByIdAsync(id);
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