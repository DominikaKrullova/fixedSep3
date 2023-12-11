using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentLogic studentLogic;

    public StudentsController(IStudentLogic studentLogic)
    {
        this.studentLogic = studentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateAsyncStudent(StudentCreationDto dto)
    {
        try
        {
            var student = await studentLogic.CreateAsyncStudent(dto);
            return Created($"/students/{student.UserId}", student);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAsyncStudent([FromQuery] string? viaID)
    {
        try
        {
            SearchUserParametersDto parameters = new(viaID);
            var students = await studentLogic.GetAsyncStudent(parameters);
            return Ok(students);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}