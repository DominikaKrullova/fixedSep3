namespace Domain.DTOs;

public class GradeCreationDto
{
    public int Id { get; set; }
    public string ExamId { get; set; }
    public string StudentId { get; set; }
    public int StudentGrade { get; set; }
    
    public GradeCreationDto(){}

    public GradeCreationDto(string examId, string studentId, int studentGrade)
    {
        ExamId = examId;
        StudentId = studentId;
        StudentGrade = studentGrade;
    }
}