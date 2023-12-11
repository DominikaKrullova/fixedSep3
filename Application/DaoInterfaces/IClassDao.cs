using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IClassDao
{
    Task<SchoolClass> CreateAsyncClass(SchoolClass schoolClass);
    Task<IEnumerable<SchoolClass>> GetAsyncClass(SearchClassParametersDto searchClassParameters);
    Task<SchoolClass?> GetByIdClassAsync(int id);
}