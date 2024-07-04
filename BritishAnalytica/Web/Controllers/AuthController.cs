using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;
using Web.Common;

namespace Web.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ResponseModelBase> Login(UserLoginDto dto)
    {
        var res = await _authService.Login(dto);
        return new ResponseModelBase(res);
    }

    [HttpPost]
    public async Task<ResponseModelBase> LogOut(long id)
    {
        var res =await _authService.LogOut(id);
        
        return new ResponseModelBase(res);
    }
    
    
    
    [HttpGet, AllowAnonymous]
    public async Task<string> GetToken()
    {
        return _tokenService.GetToken();
    }


}
