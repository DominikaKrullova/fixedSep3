namespace Domain.DTOs;

public class SearchExamParametersDto
{
    public SearchExamParametersDto(string? examName)
    {
        ExamName = examName;
    }

    public SearchExamParametersDto(int? examId)
    {
        ExamId = examId;
    }


    public string? ExamName { get; }
    public int? ExamId { get; }
}