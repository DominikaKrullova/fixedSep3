using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Domain
{
    public class ClassConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                string[] parts = stringValue.Split(';');

                if (parts.Length == 4 &&
                    int.TryParse(parts[2], out int id) &&
                    !string.IsNullOrWhiteSpace(parts[0]) &&
                    !string.IsNullOrWhiteSpace(parts[1]))
                {
                    var students = parts[3].Split(',').ToList();
                    SchoolClass schoolClassObject = new SchoolClass
                    {
                        Name = parts[0],
                        Id = id,
                        TeacherId = parts[1],
                        Students = students
                    };

                    return schoolClassObject;
                }
                else
                {
                    throw new FormatException("Invalid format for converting from string to Class object.");
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is SchoolClass classObject)
            {
                if (!string.IsNullOrWhiteSpace(classObject.Name) && !string.IsNullOrWhiteSpace(classObject.TeacherId))
                {
                    string students = string.Join(",", classObject.Students);
                    return $"{classObject.Name};{classObject.TeacherId};{classObject.Id};{students}";
                }
                else
                {
                    throw new InvalidOperationException("Invalid Class object properties for converting to string.");
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
