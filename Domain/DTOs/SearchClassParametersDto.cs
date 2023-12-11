namespace Domain.DTOs;

public class SearchClassParametersDto
{
    public SearchClassParametersDto(string? className)
    {
        ClassName = className;
    }

    public string? ClassName { get; }
}