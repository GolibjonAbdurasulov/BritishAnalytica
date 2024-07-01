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
    
    // [HttpGet]
    // public async Task<string> GenerateAccessToken()
    // {
    //     var authSection = _configuration.GetSection("Jwt");
    //     var issuer = authSection["Issuer"];
    //     var audience = authSection["Audience"];
    //     var secretKey = authSection["SecretKey"];
    //     var expireTimeSpan = Convert.ToInt32(authSection["ExpiresInMinutes"]);
    //     
    //     
    //     var token = new JwtSecurityToken(
    //         issuer: issuer,
    //         audience: audience,
    //         expires: DateTime.UtcNow.AddMinutes(expireTimeSpan),
    //         signingCredentials: new SigningCredentials(
    //             new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    //             SecurityAlgorithms.HmacSha256Signature
    //         ));
    //
    //     var hash = new JwtSecurityTokenHandler().WriteToken(token);
    //
    //     return hash;
    // }

    private async Task<IEnumerable<Claim>> GetUserClaims(long userId)
    {
        // Implement logic to retrieve user claims here
        // For example:
        var user = await _authService.GetUser(userId);

        if (user == null)
        {
            throw new ApplicationException($"User with ID {userId} not found.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role) // Example claim, replace with actual user roles
            // Add other claims as needed
        };

        return claims;
    }
    
     
    [HttpGet, AllowAnonymous]
   
    public async Task<string> GetToken()
    {
        return _tokenService.GetToken();
    }


}
