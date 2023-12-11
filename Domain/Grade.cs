namespace Domain;

public class Grade
{
    public int Id { get; set; }
    public string ExamId { get; set; }
    public string StudentId { get; set; }
    public int StudentGrade { get; set; }
    
    public Grade(){}
    
    public Grade(int id, string examId, string studentId, int studentGrade)
    {
        Id = id;
        ExamId = examId;
        StudentId = studentId;
        StudentGrade = studentGrade;
    }
}