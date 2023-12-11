namespace Domain.DTOs;

public class UpdateGradeDto
{
    public string ExamId { get; set; }
    public string StudentId { get; set; }
    public int StudentGrade { get; set; }

    public UpdateGradeDto(string examId, string studentId, int studentGrade)
    {
        ExamId = examId;
        StudentId = studentId;
        StudentGrade = studentGrade;
    }
}