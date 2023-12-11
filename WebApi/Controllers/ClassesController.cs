using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassesController : ControllerBase
{
    private readonly IClassLogic classLogic;

    public ClassesController(IClassLogic classLogic)
    {
        this.classLogic = classLogic;
    }


    [HttpPost]
    public async Task<ActionResult<SchoolClass>> CreateAsyncClass([FromBody] ClassCreationDto dto)
    {
        try
        {
            var created = await classLogic.CreateAsyncClass(dto);
            return Created($"/classes/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<SchoolClass>>> GetAsync([FromQuery] string? className = null)
    {
        try
        {
            SearchClassParametersDto parameters = new(className);
            var classes = await classLogic.GetAsyncClass(parameters);
            return Ok(classes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}