using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IGradeService
{
    Task PushGrade(GradeCreationDto dto);
    Task<IEnumerable<Grade>> GetGrades();
    Task<IEnumerable<Grade>> GetGradesByExamId(string examId);
    Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId);
    Task<Grade> GetGradeById(int id);
    Task UpdateGrade(UpdateGradeDto dto);
}