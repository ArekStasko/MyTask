using MyTask.IdP.Data.DTO;
using MyTask.IdP.Data.Models;

namespace MyTask.IdP.Services.UserService;

public interface IUserService
{
    public string Register(UserDTO userDto);
    public string Login(UserDTO userDto);
}