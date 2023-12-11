using System.Text.Json.Serialization;

namespace Domain;

public class Teacher : User
{
    [JsonConstructor]
    public Teacher(string id, string password, string name) : base(id, password)
    {
        Name = name;
    }

    public Teacher()
    {
    }

    public int UserId { get; set; }

    public string Name { get; set; }
    public string UserType ="Teacher";
}