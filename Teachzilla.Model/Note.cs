using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachzilla.Model
{
    public class Note
    {
        [Key]
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public Student? Student { get; set; }
        public Homework? Homework { get; set; }
        public Lesson? Lesson { get; set; }

        public Note() { 
            this.Text = string.Empty;
        }

        public string GenerateHeader()
        {
            var elements = new List<string>();


            if (Student != null)
            {
                elements.Add($"Student: <a href='student/{Student.ID}'>{Student.Name}</a>");
            }
            if (Homework != null)
            {
                elements.Add($"Homework: {Homework.Description}");
            }
            if (Lesson != null)
            {
                elements.Add($"Lesson: {Lesson.LessonDate.ToLocalTime().DateTime.ToShortDateString()}");
            }

            return String.Join(", ", elements );
        }
        public string GenerateFooter()
        {
            return $"Created: {Created.ToLocalTime().DateTime.ToShortDateString()} {Created.ToLocalTime().DateTime.ToShortTimeString()}, Updated: {Updated.ToLocalTime().DateTime.ToShortDateString()} {Updated.ToLocalTime().DateTime.ToShortTimeString()}";
        }
    }
}
