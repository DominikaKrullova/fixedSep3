using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.LogicInterfaces;


namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class GradesController : ControllerBase
{
    private readonly IGradeLogic gradeLogic;
    
    public GradesController(IGradeLogic gradeLogic)
    {
        this.gradeLogic = gradeLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Grade>> PushGrade([FromBody] GradeCreationDto dto)
    {
        try
        {
            var grade = await gradeLogic.PushGrade(dto);
            return Created($"/grades/{grade.Id}", grade);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
    {
        try
        {
            var grades = await gradeLogic.GetGrades();
            return Ok(grades);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, Route("by-examId")]
    public async Task<ActionResult<IEnumerable<Grade>>> GetGradesByExamId(string examId)
    {
        try
        {
            var grades = await gradeLogic.GetGradesByExamId(examId);
            return Ok(grades);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("by-studentID")]
    public async Task<ActionResult<IEnumerable<Grade>>> GetGradesByStudentUd(string studentId)
    {
        try
        {
            var grades = await gradeLogic.GetGradesByStudentId(studentId);
            return Ok(grades);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}