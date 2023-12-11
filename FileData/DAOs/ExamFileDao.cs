using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class ExamFileDao : IExamDao
{
    private readonly FileContext context;


    public ExamFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Exam> CreateAsyncExam(Exam exam)
    {
        var id = 1;
        if (context.Exams.Any())
        {
            id = context.Exams.Max(e => e.IdOfExam);
            id++;
        }

        exam.IdOfExam = id;

        context.Exams.Add(exam);
        context.SaveChanges();

        return Task.FromResult(exam);
    }

    public Task<IEnumerable<Exam>> GetAsyncExam(SearchExamParametersDto searchExamParameters)
    {
        var exams = context.Exams.AsEnumerable();
        if (searchExamParameters.ExamName != null)
            exams = context.Exams.Where(e =>
                e.NameOfExam.Contains(searchExamParameters.ExamName, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(exams);
    }

    public Task<IEnumerable<Exam>> GetByIdAsyncExam(SearchExamParametersDto searchExamParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Exam?> GetByIdAsyncExam(int id)
    {
        var existing = context.Exams.FirstOrDefault(e => e.IdOfExam == id);
        return Task.FromResult(existing);
    }
}