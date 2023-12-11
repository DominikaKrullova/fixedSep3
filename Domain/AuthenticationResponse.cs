using System.Text.Json.Serialization;

namespace Domain;

public class AuthenticationResponse
{
    public string token { get; set; }
}