using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Azure.Core;
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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b"u8.ToArray();

            var claims = new List<Claim>
            {
                new("userid", user.Id.ToString())
            };

            
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        } 
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
            
    }                                  

}
