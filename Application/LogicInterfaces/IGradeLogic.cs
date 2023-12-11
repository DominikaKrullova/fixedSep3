using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IGradeLogic
{
    Task<Grade> PushGrade(GradeCreationDto dto);
    Task<IEnumerable<Grade>> GetGrades();
    Task<IEnumerable<Grade>> GetGradesByExamId(string examId);
    Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId);
    Task<Grade> GetGradeById(int id);
    Task UpdateGrade(UpdateGradeDto dto);
}