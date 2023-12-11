using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ExamHttpClient : IExamService
{
    private readonly HttpClient client;

    public ExamHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task CreateExam(ExamCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/exams", dto);
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<Exam>> GetExam(string? name = null)
    {
        string uri = "/exams";
        if (!string.IsNullOrEmpty(name))
        {
            uri += $"?Name={name}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Exam> exams = JsonSerializer.Deserialize<IEnumerable<Exam>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return exams;
    }

    public async Task<IEnumerable<Exam>> GetExamById(int id)
    {
        string uri = "/exams";
        if (id != 0)
        {
            uri += $"?Id={id}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Exam> exams = JsonSerializer.Deserialize<IEnumerable<Exam>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return exams;
    }

}