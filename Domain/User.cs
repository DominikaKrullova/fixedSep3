using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public User(string id, string password)
    {
        Id = id;
        Password = password;
    }

    public User()
    {
    }

    [JsonPropertyName("Id")] public string Id { get; set; }

    [JsonPropertyName("Password")] public string Password { get; set; }
}