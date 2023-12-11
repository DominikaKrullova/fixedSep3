namespace Domain.DTOs;

public class SupervisorCreationDto : UserCreationDto
{
    public SupervisorCreationDto(string id, string password, string name) : base(id, password, name)
    {
    }
}