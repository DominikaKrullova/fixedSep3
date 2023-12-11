using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IExamLogic
{
    Task<Exam> CreateAsyncExam(ExamCreationDto dto);
    Task<IEnumerable<Exam>> GetAsyncExam(SearchExamParametersDto searchExamParametersDto);
    Task<IEnumerable<Exam>> GetByIdAsyncExam(SearchExamParametersDto searchExamParametersDto);

}