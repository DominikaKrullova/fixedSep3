using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class UserCreationDto
{
    public UserCreationDto(string id, string password, string name)
    {
        Id = id;
        Password = password;
        Name = name;
    }

    [JsonConstructor]
    public UserCreationDto(string id)
    {
        Id = id;
    }

    public UserCreationDto()
    {
    }

    public string Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}