using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Teacher> Teachers
    {
        get
        {
            LoadData();
            return dataContainer!.Teachers;
        }
    }
    public ICollection<Grade> Grades
    {
        get
        {
            LoadData();
            return dataContainer!.Grades;
        }
    }

    public ICollection<Student> Students
    {
        get
        {
            LoadData();
            return dataContainer!.Students;
        }
    }

    public ICollection<Supervisor> Supervisors
    {
        get
        {
            LoadData();
            return dataContainer!.Supervisors;
        }
    }

    public ICollection<SchoolClass> Classes
    {
        get
        {
            LoadData();
            return dataContainer!.Classes;
        }
    }

    public ICollection<Exam> Exams
    {
        get
        {
            LoadData();
            return dataContainer!.Exams;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (!File.Exists(filePath))
        {
            dataContainer = new DataContainer
            {
                Teachers = new List<Teacher>(),
                Students = new List<Student>(),
                Supervisors = new List<Supervisor>(),
                Exams = new List<Exam>(),
                Classes = new List<SchoolClass>()
            };
            return;
        }

        var content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }


    public void SaveChanges()
    {
        var serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}