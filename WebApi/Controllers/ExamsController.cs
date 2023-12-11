using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamsController : ControllerBase
{
    private readonly IExamLogic examLogic;

    public ExamsController(IExamLogic examLogic)
    {
        this.examLogic = examLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Exam>> CreateAsyncExam([FromBody] ExamCreationDto dto)
    {
        try
        {
            var exam = await examLogic.CreateAsyncExam(dto);
            return Created($"/exams/{exam.IdOfExam}", exam);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exam>>> GetAsyncExam([FromQuery] string? examName)
    {
        try
        {
            SearchExamParametersDto parameters = new(examName);
            var exams = await examLogic.GetAsyncExam(parameters);
            return Ok(exams);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    

}