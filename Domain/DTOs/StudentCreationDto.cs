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


    public int UserId { get; set; }
    //[JsonPropertyName("Class")]
    //public string AssignedClass { get; set; }
}