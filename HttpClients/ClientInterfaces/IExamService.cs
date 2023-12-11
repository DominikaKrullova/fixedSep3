using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IExamService
{
    Task CreateExam(ExamCreationDto dto);
    Task<IEnumerable<Exam>> GetExam(string? name = null);
    Task<IEnumerable<Exam>> GetExamById(int id);


}