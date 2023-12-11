using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class ClassFileDao : IClassDao
{
    private readonly FileContext context;

    public ClassFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<SchoolClass> CreateAsyncClass(SchoolClass schoolClass)
    {
        var id = 1;
        if (context.Classes.Any())
        {
            id = context.Classes.Max(c => c.Id);
            id++;
        }

        schoolClass.Id = id;

        context.Classes.Add(schoolClass);
        context.SaveChanges();

        return Task.FromResult(schoolClass);
    }

    public Task<IEnumerable<SchoolClass>> GetAsyncClass(SearchClassParametersDto searchClassParameters)
    {
        var classes = context.Classes.AsEnumerable();
        if (searchClassParameters.ClassName != null)
            classes = context.Classes.Where(c =>
                c.Name.Contains(searchClassParameters.ClassName, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(classes);
    }

    public Task<SchoolClass?> GetByIdClassAsync(int id)
    {
        var existing = context.Classes.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(existing);
    }
}