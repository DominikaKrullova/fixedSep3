using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class ClassLogic : IClassLogic
{
    private readonly IClassDao classDao;
    private readonly IStudentDao studentDao;
    private readonly ITeacherDao teacherDao;
    private List<string> studentIdList;

    public ClassLogic(IClassDao classDao, IStudentDao studentDao, ITeacherDao teacherDao)
    {
        this.classDao = classDao;
        this.teacherDao = teacherDao;
        this.studentDao = studentDao;
    }

    public async Task<SchoolClass> CreateAsyncClass(ClassCreationDto dto)
    {
        var existing = await classDao.GetByIdClassAsync(dto.Id);
        if (existing != null) throw new Exception("Id already taken!");


        var toCreate = new SchoolClass(dto.Name, dto.TeacherID, dto.Id, dto.Students);
        //Console.WriteLine($"Student IDs for this class: {studentIdList}");
        await classDao.CreateAsyncClass(toCreate);

        return toCreate;
    }

    public Task<IEnumerable<SchoolClass>> GetAsyncClass(SearchClassParametersDto searchClassParameters)
    {
        return classDao.GetAsyncClass(searchClassParameters);
    }
}