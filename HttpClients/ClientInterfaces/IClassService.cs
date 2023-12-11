using Domain;
using Domain.DTOs;
namespace HttpClients.ClientInterfaces;
public interface IClassService
{
    Task CreateAsyncClass(ClassCreationDto dto);
    Task<IEnumerable<SchoolClass>> GetClass(string? name = null);
} 