using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTask.IdP.Data.DTO;
using MyTask.IdP.Data.Models;
using MyTask.IdP.Services.UserService;

namespace MyTask.IdP.Controllers;
    [Route("idp/users/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpPost(Name = "Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public ActionResult<string> Register(UserDTO userDto)
        {
            string token = _userService.Register(userDto);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost(Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public ActionResult<string> Login(UserDTO userDto)
        {
            string token = _userService.Login(userDto);
            return Ok(token);
        }
    }
