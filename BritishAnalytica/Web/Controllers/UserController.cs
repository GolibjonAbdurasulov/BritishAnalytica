using System.Threading.Tasks;
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
    public async Task<ResponseModelBase> CreateAsync( UserCreationDto dto)
    {
       var res= await UserService.CreateAsync(dto);
        return new ResponseModelBase(res);
    }
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdateEmailAsync( UserEmailUpdateDto dto)
    {
        var user =await UserService.UpdateUserEmail(dto);
        return new ResponseModelBase(dto);
    }
    
    [HttpPut]
    public async Task<ResponseModelBase> UpdatePasswordAsync( UserPasswordUpdateDto dto)
    {
        var res =await UserService.UpdateUserPassword(dto);
        return new ResponseModelBase(res);
    }
    
    [HttpDelete]
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
}