using System.Text.Json.Serialization;

namespace Domain;

public class Supervisor : User
{
    [JsonConstructor]
    public Supervisor(string id, string password, string name) : base(id, password)
    {
        Name = name;
    }

    public Supervisor()
    {
    }
    
    
    public int UserId { get; set; }
    public string Name { get; set; }


}