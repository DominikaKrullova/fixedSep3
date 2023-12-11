using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface ISupervisorLogic
{
    Task<Supervisor> CreateAsyncSupervisor(SupervisorCreationDto userToCreate);
    public Task<IEnumerable<Supervisor>> GetAsyncSupervisor(SearchUserParametersDto searchParameters);
}