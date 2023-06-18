using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MyTask.IdP.Data;
using MyTask.IdP.Data.Models;

namespace MyTask.IdP.Services.TokenService;

public class TokenService : ITokenService
{

    public string GenerateToke(User user)
    {
        try
        {
            //This is only for test purposes
            var securityKey = new SymmetricSecurityKey("NoHiddenKey"u8.ToArray());
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Username", user.UserName),
            };

            var token = new JwtSecurityToken(
                null, 
                null, 
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
            
    }                                  

}
