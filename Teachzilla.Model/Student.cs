using System.ComponentModel.DataAnnotations;

namespace Teachzilla.Model
{
    public class Student
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<Homework> Homework{ get; }
        public ICollection<Note> Notes { get; }
        public ICollection<Lesson> Lessons{ get; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        public Student()
        {
            Phone = String.Empty;
            Address = String.Empty;
        }
    }
}
