﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTask.API.Services.DTO;
using MyTask.API.Services.Services.RaportControllers;

namespace MyTask.API.Controllers;

[Route("api/raports/[action]")]
[ApiController]
public class RaportController : BaseController
{
    private readonly IRaportService _raportService;

    public RaportController(IRaportService raportService)
    {
        _raportService = raportService;
    }

    [Authorize]
    [HttpPost(Name = "GenerateRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RaportDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<RaportDTO>> Generate([FromQuery] int projectId)
    {
        var result = await _raportService.Generate(projectId, UserId);
        return Ok(result);
    }

    [Authorize]
    [HttpPost(Name = "DeleteRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<bool>> Delete([FromQuery] int id)
    {
        var result = await _raportService.Delete(id, UserId);
        return Ok(result);
    }

    [Authorize]
    [HttpGet(Name = "GetRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RaportDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<List<RaportDTO>>> Get()
    {
        var result = await _raportService.Get(UserId);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet(Name = "GetSingleRaport")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RaportDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<ActionResult<RaportDTO>> GetSingle([FromQuery] int id)
    {
        var result = await _raportService.GetSingle(id, UserId);
        return Ok(result);
    }
}