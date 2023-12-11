using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface ISupervisorDao
{
    Task<Supervisor> CreateAsyncSupervisor(Supervisor supervisor);
    Task<Supervisor?> GetByIdAsyncSupervisor(string id);
    public Task<IEnumerable<Supervisor>> GetAsyncSupervisor(SearchUserParametersDto searchParameters);
}