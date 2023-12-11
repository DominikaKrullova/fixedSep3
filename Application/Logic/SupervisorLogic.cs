using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class SupervisorLogic : ISupervisorLogic
{
    
    private readonly ISupervisorDao supervisorDao;

    public SupervisorLogic(ISupervisorDao supervisorDao)
    {
        this.supervisorDao = supervisorDao;
    }
    
    
    public async Task<Supervisor> CreateAsyncSupervisor(SupervisorCreationDto userToCreate)
    {
        var existing = await supervisorDao.GetByIdAsyncSupervisor(userToCreate.Id);
        if (existing != null)
            throw new Exception("Id already taken!");
        
        ValidateData(userToCreate);



        var toCreate = new Supervisor(userToCreate.Id, userToCreate.Password, userToCreate.Name);

        await supervisorDao.CreateAsyncSupervisor(toCreate);

        return toCreate;
    }

    public Task<IEnumerable<Supervisor>> GetAsyncSupervisor(SearchUserParametersDto searchParameters)
    {
        return supervisorDao.GetAsyncSupervisor(searchParameters);

    }
    
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        var id = userToCreate.Id;

        if (id.Length != 6)
            throw new Exception("VIA ID must be 6 characters!");

        var password = userToCreate.Password;

        if (password.Length < 7) throw new Exception("Password must be at least 8 characters. ");
    }
}