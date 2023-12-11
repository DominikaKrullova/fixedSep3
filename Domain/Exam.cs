using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace Domain;

public class Exam
{

    [JsonConstructor]
    public Exam(){}
    public Exam(int idOfExam, string nameOfExam, string dateTime, SchoolClass? class_)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        DateTime = dateTime;
        Class = class_;
    }

    public string NameOfExam { get; set; }
    //public int Grade { get; set; }
    public SchoolClass? Class { get; set; }
    public int IdOfExam { get; set; }
    public string DateTime { get; set; }
}