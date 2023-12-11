using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly IAuthService authService;

    public AuthController(IConfiguration config, IAuthService authService)
    {
        this.config = config;
        this.authService = authService;
    }

    private List<Claim> GenerateClaimsStudent(Student student)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, student.Id),
        };
        return claims.ToList();
    }
    
    private List<Claim> GenerateClaimsTeacher(Teacher teacher)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, teacher.Id),
        };
        return claims.ToList();
    }
    
    private List<Claim> GenerateClaimsSupervisor(Supervisor supervisor)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, supervisor.Id),
        };
        return claims.ToList();
    }
    
    private string GenerateJwtStudent(Student student)
    {
        List<Claim> claims = GenerateClaimsStudent(student);
    
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
    
        JwtHeader header = new JwtHeader(signIn);
    
        JwtPayload payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims, 
            null,
            DateTime.UtcNow.AddMinutes(60));
    
        JwtSecurityToken token = new JwtSecurityToken(header, payload);
    
        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }
    
    
    private string GenerateJwtTeacher(Teacher teacher)
    {
        List<Claim> claims = GenerateClaimsTeacher(teacher);
    
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
    
        JwtHeader header = new JwtHeader(signIn);
    
        JwtPayload payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims, 
            null,
            DateTime.UtcNow.AddMinutes(60));
    
        JwtSecurityToken token = new JwtSecurityToken(header, payload);
    
        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }
    
    private string GenerateJwtSupervisor(Supervisor supervisor)
    {
        List<Claim> claims = GenerateClaimsSupervisor(supervisor);
    
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
    
        JwtHeader header = new JwtHeader(signIn);
    
        JwtPayload payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims, 
            null,
            DateTime.UtcNow.AddMinutes(60));
    
        JwtSecurityToken token = new JwtSecurityToken(header, payload);
    
        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }
    
    
    [HttpPost, Route("loginStudent")]
    public async Task<ActionResult> Login([FromBody] StudentLoginDto studentLoginDto)
    {
        try
        {
            Student student = await authService.GetStudent(studentLoginDto.Id, studentLoginDto.Password);
            await authService.ValidateStudent(student.Id, student.Password);
            string token = GenerateJwtStudent(student);
    
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpPost, Route("loginTeacher")]
    public async Task<ActionResult> Login([FromBody] TeacherLoginDto teacherLoginDto)
    {
        try
        {
            Teacher teacher = await authService.GetTeacher(teacherLoginDto.Id, teacherLoginDto.Password);
            await authService.ValidateTeacher(teacher.Id, teacher.Password);
            string token = GenerateJwtTeacher(teacher);
            
            return Ok(token);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost, Route("loginSupervisor")]
    public async Task<ActionResult> Login([FromBody] SupervisorLoginDto supervisorLoginDto)
    {
        try
        {
            Supervisor supervisor = await authService.GetSupervisor(supervisorLoginDto.Id, supervisorLoginDto.Password);
            await authService.ValidateSupervisor(supervisor.Id, supervisor.Password);
            string token = GenerateJwtSupervisor(supervisor);
            
            return Ok(token);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}