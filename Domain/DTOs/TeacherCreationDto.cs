namespace Domain.DTOs;

public class TeacherCreationDto : UserCreationDto
{
    public TeacherCreationDto(string id, string password, string name) : base(id, password, name)
    {
    }
}