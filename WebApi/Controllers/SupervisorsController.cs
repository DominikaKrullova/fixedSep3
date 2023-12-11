using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SupervisorsController : ControllerBase
{
    private readonly ISupervisorLogic supervisorLogic;

    public SupervisorsController(ISupervisorLogic supervisorLogic)
    {
        this.supervisorLogic = supervisorLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Supervisor>> CreateAsyncSupervisor(SupervisorCreationDto dto)
    {
        try
        {
            var supervisor = await supervisorLogic.CreateAsyncSupervisor(dto);
            return Created($"/supervisors/{supervisor.UserId}", supervisor);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supervisor>>> GetAsyncSupervisor([FromQuery] string? viaID)
    {
        try
        {
            SearchUserParametersDto parameters = new(viaID);
            var supervisors = await supervisorLogic.GetAsyncSupervisor(parameters);
            return Ok(supervisors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}