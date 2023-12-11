namespace Domain.DTOs;

public class UserParametersDto
{
    public UserParametersDto(string idContains)
    {
        IdContains = idContains;
    }

    public string IdContains { get; }
}