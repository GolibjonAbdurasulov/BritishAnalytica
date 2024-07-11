using System.Threading.Tasks;
using DatabaseBroker.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using Web.Common;

namespace Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
   
    private IUserService UserService { get; set; }
    
    public UserController(IUserService userService)
    {
        UserService = userService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ResponseModelBase> CreateAsync( UserCreationDto dto)
    {
       var res= await UserService.CreateAsync(dto);
        return new ResponseModelBase(res);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdateEmailAsync( UserEmailUpdateDto dto)
    {
        var user =await UserService.UpdateUserEmail(dto);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> UpdatePasswordAsync( UserPasswordUpdateDto dto)
    {
        var res =await UserService.UpdateUserPassword(dto);
        return new ResponseModelBase(res);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ResponseModelBase> ChangeUserRoleAsync( ChangeUserRoleDto dto)
    {
        var res =await UserService.ChangeUserRole(dto);
        return new ResponseModelBase(res);
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<ResponseModelBase> DeleteAsync(long id)
    {
        var res =await UserService.DeleteAsync(id);
        return new ResponseModelBase(res);
    }
   
    [HttpGet]
    public async Task<ResponseModelBase> GetAsync(long id)
    {
        var res =await UserService.GetByIdAsync(id);
        return new ResponseModelBase(res);
    }
    
    
    [HttpGet]
    [Authorize]
    public async Task<ResponseModelBase> GetAllAsync()
    {
        var res =await UserService.GetAllUsers();
        return new ResponseModelBase(res);
    }
}