using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace HttpClients.Implementations;

public class GradeHttpClient : IGradeService
{
    private readonly HttpClient client;
    
    public GradeHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task PushGrade(GradeCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/grades", dto);
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        
    }

    public async Task<IEnumerable<Grade>> GetGrades()
    {
        string uri = "/grades";
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Grade> grades = JsonSerializer.Deserialize<IEnumerable<Grade>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return grades;
    }

    public async Task<IEnumerable<Grade>> GetGradesByExamId(string examId)
    {
        string uri = "/grades/by-examId";
        if (!string.IsNullOrEmpty(examId))
        {
            uri += $"?ExamId={examId}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Grade> grades = JsonSerializer.Deserialize<IEnumerable<Grade>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return grades;
    }

    public async Task<IEnumerable<Grade>> GetGradesByStudentId(string studentId)
    {
        string uri = "/grades/by-studentId";
        if (!string.IsNullOrEmpty(studentId))
        {
            uri += $"?StudentId={studentId}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Grade> grades = JsonSerializer.Deserialize<IEnumerable<Grade>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return grades;
    }

    public Task<Grade> GetGradeById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateGrade(UpdateGradeDto dto)
    {
        throw new NotImplementedException();
    }
}