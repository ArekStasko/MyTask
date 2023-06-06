using Microsoft.AspNetCore.Mvc;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.ProjectServices;

namespace MyTask.API.Controllers;
[Route("api/projects/[action]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost(Name = "CreateProject")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<ProjectDTO>> Create(ProjectDTO projectDto)
    {
        var result = await _projectService.Create(projectDto);
        return Ok(result);
    }

    [HttpPost(Name = "DeleteProject")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<bool>> Delete([FromQuery] int id)
    {
        var result = await _projectService.Delete(id);
        return Ok(result);
    }
    
    [HttpGet(Name = "GetProject")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProjectDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<List<ProjectDTO>>> Get()
    {
        var result = await _projectService.Get();
        return Ok(result);
    }
    
    [HttpGet(Name = "GetSingleProject")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<ProjectDTO>> GetSingle([FromQuery] int id)
    {
        var result = await _projectService.GetSingle(id);
        return Ok(result);
    }
}