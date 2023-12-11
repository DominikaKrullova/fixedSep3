namespace Domain.DTOs
{
    public class ExamCreationDto
    {
        public string NameOfExam { get; set; }
        public int IdOfExam { get; set; }
        public string DateTime { get; set; }
        public SchoolClass SchoolClass { get; set; }

       
        public ExamCreationDto() { }

        public ExamCreationDto(string nameOfExam, string dateTime, SchoolClass schoolClass)
        {
            NameOfExam = nameOfExam;
            DateTime = dateTime;
            SchoolClass = schoolClass;
        }
    }
}