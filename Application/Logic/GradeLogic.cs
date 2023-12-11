using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class GradeLogic : IGradeLogic
{

    private readonly IGradeDao gradeDao;

    public GradeLogic(IGradeDao gradeDao)
    {
        this.gradeDao = gradeDao;
    }
    
    public async Task<Grade> PushGrade(GradeCreationDto dto)
    {
        ValidateData(dto);
        
        var toCreate = new Grade(dto.Id, dto.ExamId, dto.StudentId, dto.StudentGrade);
        await gradeDao.PushGrade(toCreate);
        return toCreate;
    }

    public async Task<IEnumerable<Grade>> GetGrades()
    {
        return await gradeDao.GetGrades();
    }

    public async Task<IEnumerable<Grade>> GetGradesByExamId(string examId)
    {
        return await gradeDao.GetGradesByExamId(examId);
    }

    public async Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId)
    {
        return await gradeDao.GetGradesByStudentId(studentId);
    }

    public async Task<Grade> GetGradeById(int id)
    {
        return await gradeDao.GetGradeById(id);
    }

    public Task UpdateGrade(UpdateGradeDto dto)
    {
        throw new NotImplementedException();
    }

    private void ValidateData(GradeCreationDto grade)
    {
        // if (grade.StudentGrade < 0 || grade.StudentGrade > 5)
        // {
        //     throw new Exception("Invalid grade.");
        // }
    }
}