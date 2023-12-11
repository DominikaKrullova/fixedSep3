using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class GradeDao : IGradeDao
{
    private readonly FileContext context;
    
    public GradeDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Grade> PushGrade(Grade grade)
    {
        var id = 1;
        if (context.Grades.Any())
        {
            id = context.Grades.Max(g => g.Id);
            id++;
        }

        grade.Id = id;
        

        context.Grades.Add(grade);
        context.SaveChanges();

        return Task.FromResult(grade);
    }

    public Task<IEnumerable<Grade>> GetGrades()
    {
        var grades = context.Grades.AsEnumerable();
        return Task.FromResult(grades);
    }

    public Task<IEnumerable<Grade>> GetGradesByExamId(string examId)
    {
        var filteredGrades = context.Grades.Where(u =>
                u.ExamId.Contains(examId, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(filteredGrades);
    }

    public Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId)
    {
        var filteredGrades = context.Grades.Where(u =>
            u.StudentId.Contains(studentId, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(filteredGrades);
    }

    public Task<Grade> GetGradeById(int id)
    {
        Grade? grade = context.Grades.FirstOrDefault(g => g.Id == id);

        return Task.FromResult(grade);
    }

    public Task UpdateGrade(UpdateGradeDto dto)
    {
        throw new NotImplementedException();
    }
}