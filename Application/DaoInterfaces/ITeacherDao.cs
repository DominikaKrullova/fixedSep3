using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface ITeacherDao
{
    Task<Teacher> CreateAsyncTeacher(Teacher teacher);
    Task<Teacher?> GetByIdAsyncTeacher(string id);
    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters);
}