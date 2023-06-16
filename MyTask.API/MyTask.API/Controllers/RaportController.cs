using Microsoft.AspNetCore.Mvc;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.RaportControllers;

namespace MyTask.API.Controllers;

[Route("api/raports/[action]")]
[ApiController]
public class RaportController : ControllerBase
{
    private readonly IRaportService _raportService;

    public RaportController(IRaportService raportService)
    {
        _raportService = raportService;
    }

    [HttpPost(Name = "GenerateRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RaportDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<RaportDTO>> Generate([FromQuery] int projectId)
    {
        var result = await _raportService.Generate(projectId);
        return Ok(result);
    }

    [HttpPost(Name = "DeleteRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<bool>> Delete([FromQuery] int id)
    {
        var result = await _raportService.Delete(id);
        return Ok(result);
    }

    [HttpGet(Name = "GetRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RaportDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<List<RaportDTO>>> Get()
    {
        var result = await _raportService.Get();
        return Ok(result);
    }
    
    [HttpGet(Name = "GetSingleRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RaportDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<RaportDTO>> GetSingle([FromQuery] int id)
    {
        var result = await _raportService.GetSingle(id);
        return Ok(result);
    }
}