using MyTask.IdP.Data.Models;

namespace MyTask.IdP.Services.TokenService;

public interface ITokenService
{
    public string GenerateToke(User user);
}