using System.Security.Claims;
using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<Student> CreateStudent(StudentCreationDto dto);
    Task<Teacher> CreateTeacher(TeacherCreationDto dto);
    Task<IEnumerable<Teacher>> GetTeachers(string? viaId = null);
    Task<IEnumerable<Student>> GetStudents(string? viaId = null);
    Task<AuthenticationResponse> ValidateUser(string viaId, string password);
    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    Task<ClaimsPrincipal> GetAuthAsync();


}