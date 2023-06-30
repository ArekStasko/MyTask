using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.TaskControllers;

namespace MyTask.API.Controllers;

[Route("api/tasks/[action]")]
[ApiController]
public class TaskController : BaseController
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [Authorize]
    [HttpPost(Name = "CreateTask")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<bool>> Create(TaskDTO task)
    {
        var result = await _taskService.Create(task, UserId);
        return Ok(result);
    }
    
    [Authorize]
    [HttpPost(Name = "DeleteTask")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<bool>> Delete([FromQuery] int id)
    {
        var result = await _taskService.Delete(id, UserId);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet(Name = "GetTasks")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TaskDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<List<TaskDTO>>> GetTasks()
    {
        var result = await _taskService.GetAll(UserId);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet(Name = "GetTaskByProjectId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TaskDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<List<TaskDTO>>> Get([FromQuery] int projectId)
    {
        var result = await _taskService.Get(projectId, UserId);
        return Ok(result);
    }

    [Authorize]
    [HttpPost(Name = "UpdateTask")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<TaskDTO>> Update(TaskDTO task)
    {
        var result = await _taskService.Update(task, UserId);
        return Ok(result);
    }

    [Authorize]
    [HttpGet(Name = "GetSingleTask")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<TaskDTO>> GetSingle([FromQuery] int id)
    {
        var result = await _taskService.GetSingle(id, UserId);
        return Ok(result);
    }
}