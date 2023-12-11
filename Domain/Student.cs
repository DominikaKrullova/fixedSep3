using System.Text.Json.Serialization;

namespace Domain;

public class Student : User
{
    public Student(string id, string password, string name) : base(id, password)
    {
        Name = name;
        //AssignedClass = assignedToClass;
    }

    public Student()
    {
    }

    [JsonPropertyName("Name")] public string Name { get; set; }

    public int UserId { get; set; }
    public string UserType = "Student";

    //[JsonPropertyName("Class")] public string AssignedClass { get; set; }
}