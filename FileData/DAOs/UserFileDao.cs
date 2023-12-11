using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class UserFileDao : IStudentDao, ITeacherDao, ISupervisorDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }


    public Task<Student?> GetByIdAsync(string userName)
    {
        var existing = context.Students.FirstOrDefault(u =>
            u.Id.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task CreateAsyncStudent(Student student)
    {
        var userId = 1;
        if (context.Students.Any())
        {
            userId = context.Students.Max(s => s.UserId);
            userId++;
        }

        student.UserId = userId;

        context.Students.Add(student);
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters)
    {
        var students = context.Students.AsEnumerable();
        if (searchParameters.IdContains != null)
            students = context.Students.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(students);
    }

    public Task<Teacher> CreateAsyncTeacher(Teacher teacher)
    {
        var userId = 1;
        if (context.Teachers.Any())
        {
            userId = context.Teachers.Max(s => s.UserId);
            userId++;
        }

        teacher.UserId = userId;

        context.Teachers.Add(teacher);
        context.SaveChanges();

        return Task.FromResult(teacher);
    }

    public Task<Teacher?> GetByIdAsyncTeacher(string viaID)
    {
        var existing = context.Teachers.FirstOrDefault(u =>
            u.Id.Equals(viaID, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters)
    {
        var teachers = context.Teachers.AsEnumerable();
        if (searchParameters.IdContains != null)
            teachers = context.Teachers.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(teachers);
    }

    public Task<Supervisor> CreateAsyncSupervisor(Supervisor supervisor)
    {
        var userId = 1;
        if (context.Supervisors.Any())
        {
            userId = context.Supervisors.Max(s => s.UserId);
            userId++;
        }

        supervisor.UserId = userId;

        context.Supervisors.Add(supervisor);
        context.SaveChanges();

        return Task.FromResult(supervisor);
        
        
    }

    public Task<Supervisor?> GetByIdAsyncSupervisor(string id)
    {
        var existing = context.Supervisors.FirstOrDefault(s =>
            s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Supervisor>> GetAsyncSupervisor(SearchUserParametersDto searchParameters)
    {
        var supervisors = context.Supervisors.AsEnumerable();
        if (searchParameters.IdContains != null)
            supervisors = context.Supervisors.Where(s =>
                s.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(supervisors);
        
        
        
    }
}