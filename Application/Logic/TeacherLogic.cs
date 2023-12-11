using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class TeacherLogic : ITeacherLogic
{
    private readonly ITeacherDao userDao;
    private ITeacherLogic _teacherLogicImplementation;

    public TeacherLogic(ITeacherDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<Teacher> CreateAsyncTeacher(TeacherCreationDto dto)
    {
        var existing = await userDao.GetByIdAsyncTeacher(dto.Id);
        if (existing != null)
            throw new Exception("Id already taken!");

        ValidateData(dto);


        var toCreate = new Teacher(dto.Id, dto.Password, dto.Name);

        await userDao.CreateAsyncTeacher(toCreate);

        return toCreate;
    }

    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsyncTeacher(searchParameters);
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