using System.ComponentModel.DataAnnotations;
using Teachzilla.Model.Shared;

namespace Teachzilla.Model
{
    public class Student: AGuidEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public IList<Homework> Homework{ get; }
        public IList<Note> Notes { get; }
        public IList<Lesson> Lessons{ get; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        public Student()
        {
            Phone = String.Empty;
            Address = String.Empty;
            Homework = new List<Homework>();
            Notes = new List<Note>();
            Lessons = new List<Lesson>();
        }
    }
}
