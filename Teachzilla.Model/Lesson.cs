using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachzilla.Model
{
    public class Lesson
    {
        [Key]
        public Guid ID { get; set; }
        public Student Student { get; set; }
        public DateTimeOffset LessonDate { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public ICollection<Note> Notes { get; }

        public Lesson() {
        }
    }
}
