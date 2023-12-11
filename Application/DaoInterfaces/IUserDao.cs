using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string id);
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}