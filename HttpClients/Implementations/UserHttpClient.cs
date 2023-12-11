using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    public Task<AuthenticationResponse> ValidateUser(string viaId, string password)
    {
        throw new NotImplementedException();
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        throw new NotImplementedException();
    }

    public static string? Jwt { get; private set; } = "";

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }

    public async Task<Student> CreateStudent(StudentCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/students", dto);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            throw new Exception(result);
        }

        var student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<Teacher> CreateTeacher(TeacherCreationDto dto)
    {
        Console.WriteLine("1");
        var response = await client.PostAsJsonAsync("/teachers", dto);
        Console.WriteLine("2");
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        if (!response.IsSuccessStatusCode) throw new Exception(result);


        var teacher = JsonSerializer.Deserialize<Teacher>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine($"{teacher.UserId}, {teacher.Password}, {teacher.Password}");
        return teacher;
    }

    public async Task<IEnumerable<Teacher>> GetTeachers(string? viaId = null)
    {
        string uri = "/teachers";
        if (!string.IsNullOrEmpty(viaId))
        {
            uri += $"?Id={viaId}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Teacher> teachers = JsonSerializer.Deserialize<IEnumerable<Teacher>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return teachers;
    }

    public async Task<IEnumerable<Student>> GetStudents(string? viaId = null)
    {
        string uri = "/students";
        if (!string.IsNullOrEmpty(viaId))
        {
            uri += $"?Id={viaId}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Student> students = JsonSerializer.Deserialize<IEnumerable<Student>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return students;
    }
}