using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class ExamLogic : IExamLogic
{
    private readonly IClassDao classDao;
    private readonly IExamDao examDao;

    public ExamLogic(IClassDao classDao, IExamDao examDao)
    {
        this.classDao = classDao;
        this.examDao = examDao;
    }

    public async Task<Exam> CreateAsyncExam(ExamCreationDto dto)
    {
        var create = new Exam(dto.IdOfExam, dto.NameOfExam, dto.DateTime, dto.SchoolClass);

        await examDao.CreateAsyncExam(create);
        return create;
    }

    public Task<IEnumerable<Exam>> GetAsyncExam(SearchExamParametersDto searchExamParametersDto)
    {
        return examDao.GetAsyncExam(searchExamParametersDto);
    }
    

    public Task<IEnumerable<Exam>> GetByIdAsyncExam(SearchExamParametersDto searchExamParametersDto)
    {
        return examDao.GetByIdAsyncExam(searchExamParametersDto);
    }
}