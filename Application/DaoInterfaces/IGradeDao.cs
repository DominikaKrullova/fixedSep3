using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IGradeDao
{
    Task<Grade> PushGrade(Grade grade);
    Task<IEnumerable<Grade>> GetGrades();
    Task<IEnumerable<Grade>> GetGradesByExamId(string examId);
    Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId);
    Task<Grade> GetGradeById(int id);
    Task UpdateGrade(UpdateGradeDto dto);
}