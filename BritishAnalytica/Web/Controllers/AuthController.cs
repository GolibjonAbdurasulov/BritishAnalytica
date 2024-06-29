using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using Web.Common;

namespace Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private IAuthService AuthService { get; set; }
    
    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost]
    public async Task<ResponseModelBase> Login(UserLoginDto dto)
    {
        var res=await AuthService.Login(dto);
        return new ResponseModelBase(res);
    }
}