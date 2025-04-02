using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachzilla.Model.Shared;

namespace Teachzilla.Model
{
    public class Homework: AGuidEntity
    {
        public Student Student { get; set; }
        public Guid StudentID { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Due { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public ICollection<Note> Notes { get; }
        public Homework() { 
            Due = DateTimeOffset.Now;
        }

    }
}
