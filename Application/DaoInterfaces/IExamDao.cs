using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IExamDao
{
    Task<Exam> CreateAsyncExam(Exam exam);
    Task<IEnumerable<Exam>> GetAsyncExam(SearchExamParametersDto searchExamParameters);
    Task<IEnumerable<Exam>> GetByIdAsyncExam(SearchExamParametersDto searchExamParameters);

}