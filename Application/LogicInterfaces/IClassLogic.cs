using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IClassLogic
{
    Task<SchoolClass> CreateAsyncClass(ClassCreationDto dto);
    Task<IEnumerable<SchoolClass>> GetAsyncClass(SearchClassParametersDto searchClassParameters);
}