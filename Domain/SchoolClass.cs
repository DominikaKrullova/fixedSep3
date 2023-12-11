using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Domain
{
    [TypeConverter(typeof(ClassConverter))] // Apply the TypeConverterAttribute
    public class SchoolClass
    {
        public string Name { get; set; }

        public string TeacherId { get; set; }

        public List<string?> Students { get; set; } = new List<string?>();

        public int Id { get; set; }

        // Other properties and constructors...

        // Ensure you have a parameterless constructor for deserialization
        public SchoolClass() { }

        public SchoolClass(string name, string teacherId, int id, List<string?> students)
        {
            Name = name;
            Id = id;
            TeacherId = teacherId;
            Students = students;
        }
    }
}