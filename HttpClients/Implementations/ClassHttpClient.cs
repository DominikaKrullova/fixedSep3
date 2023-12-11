using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;
namespace HttpClients.Implementations;
public class ClassHttpClient : IClassService
{
    private readonly HttpClient client;
    public ClassHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task CreateAsyncClass(ClassCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/classes", dto);
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
    public async Task<IEnumerable<SchoolClass>> GetClass(string? name)
    {
        Console.WriteLine("The program got to the httpclient point");
        string uri = "/classes";
        if (!string.IsNullOrEmpty(name))
        {
            uri += $"?name={name}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        Console.WriteLine("1");
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine("2");
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            throw new Exception(result);
        }
        IEnumerable<SchoolClass> classes = JsonSerializer.Deserialize<IEnumerable<SchoolClass>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return classes;
    }
}