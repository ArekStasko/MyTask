using Microsoft.AspNetCore.Mvc;

namespace MyTask.API.Controllers;

public class BaseController : ControllerBase
{
    protected string UserId => HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
}