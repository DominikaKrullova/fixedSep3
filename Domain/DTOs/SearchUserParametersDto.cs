namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public SearchUserParametersDto(string? idContains)
    {
        IdContains = idContains;
    }
    

    public string? IdContains { get; }
}