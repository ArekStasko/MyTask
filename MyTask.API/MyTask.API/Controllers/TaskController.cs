using Microsoft.AspNetCore.Mvc;

namespace MyTask.API.Controllers;

public class TaskController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}