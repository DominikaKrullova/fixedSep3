using Domain;

namespace WebApi.Services;

public interface IAuthService
{
    Task<Student> GetStudent(string id, string password);
    Task<Teacher> GetTeacher(string id, string password);
    Task<Supervisor> GetSupervisor(string id, string password);

    Task<Student> ValidateStudent(string id, string password);
    Task<Teacher> ValidateTeacher(string id, string password);
    Task<Supervisor> ValidateSupervisor(string id, string password);
}