using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IStudentDao
{
    Task<Student?> GetByIdAsync(string id);
    Task CreateAsyncStudent(Student student);
    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters);
}