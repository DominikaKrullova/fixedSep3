namespace Domain.DTOs;

public class StudentCreationDto : UserCreationDto
{


    public StudentCreationDto(string id, string password, string name) : base(id, password, name)
    {
        Name = name;
        //AssignedClass = assignedToClass;
    }

    public StudentCreationDto()
    {
    }

    //[JsonPropertyName("UserId")]\\
    //[JsonPropertyName("Class")]
    //public string AssignedClass { get; set; }
}