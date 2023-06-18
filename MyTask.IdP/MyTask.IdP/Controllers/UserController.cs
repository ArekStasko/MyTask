using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTask.IdP.Data.DTO;
using MyTask.IdP.Data.Models;
using MyTask.IdP.Services.UserService;

namespace MyTask.IdP.Controllers;

public class UserController
{
    [Route("idp/users/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpPost(Name = "RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public ActionResult<string> Register(UserDTO userDto)
        {
            string token = _userService.Register(userDto);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost(Name = "RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public ActionResult<string> Login(UserDTO userDto)
        {
            string token = _userService.Login(userDto);
            return Ok(token);
        }
    }
}