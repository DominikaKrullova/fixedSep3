using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IStudentLogic studentLogic;
    private readonly ITeacherLogic teacherLogic;
    private readonly ISupervisorLogic supervisorLogic;

    
    public AuthService(IStudentLogic studentLogic, ITeacherLogic teacherLogic, ISupervisorLogic supervisorLogic)
    {
        this.studentLogic = studentLogic ?? throw new ArgumentNullException(nameof(studentLogic));
        this.teacherLogic = teacherLogic ?? throw new ArgumentNullException(nameof(teacherLogic));
        this.supervisorLogic = supervisorLogic ?? throw new ArgumentNullException(nameof(supervisorLogic));

    }
    
    
    public async Task<Student> GetStudent(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Student> students = await studentLogic.GetAsyncStudent(parameters);
        Student? student = students.FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (student != null)
        {
            return student;
        }
        else
        {
            throw new Exception("List of users empty.");
        }
    }


    public async Task<Teacher> GetTeacher(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Teacher> teachers = await teacherLogic.GetAsyncTeacher(parameters);
        Teacher? teacher = teachers.FirstOrDefault(t => t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (teacher != null)
        {
            return teacher;
        }
        else
        {
            throw new Exception("List of users empty.");
        }
    }

    public async Task<Supervisor> GetSupervisor(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Supervisor> supervisors = await supervisorLogic.GetAsyncSupervisor(parameters);
        Supervisor? supervisor = supervisors.FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (supervisor != null)
        {
            return supervisor;
        }
        else
        {
            throw new Exception("List of users empty.");
        }
    }

    public async Task<Student> ValidateStudent(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Student> students = await studentLogic.GetAsyncStudent(parameters);
        Student? existingStudent = students.FirstOrDefault(s => 
            s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Username: {existingStudent.Id}, Password: {existingStudent.Password}");

        if (existingStudent == null)
        {
            throw new Exception("User not found");
        }

        if (!existingStudent.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingStudent;
    }
    
    public async Task<Teacher> ValidateTeacher(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Teacher> teachers = await teacherLogic.GetAsyncTeacher(parameters);
        Teacher? existingTeacher = teachers.FirstOrDefault(t => 
            t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Username: {existingTeacher.Id}, Password: {existingTeacher.Password}");

        if (existingTeacher == null)
        {
            throw new Exception("User not found");
        }

        if (!existingTeacher.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingTeacher;
    }

    public async Task<Supervisor> ValidateSupervisor(string id, string password)
    {
        SearchUserParametersDto parameters = new(id);
        IEnumerable<Supervisor> supervisors = await supervisorLogic.GetAsyncSupervisor(parameters);
        Supervisor? existingSupervisor = supervisors.FirstOrDefault(s => 
            s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Username: {existingSupervisor.Id}, Password: {existingSupervisor.Password}");

        if (existingSupervisor == null)
        {
            throw new Exception("User not found");
        }

        if (!existingSupervisor.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingSupervisor;
    }
}