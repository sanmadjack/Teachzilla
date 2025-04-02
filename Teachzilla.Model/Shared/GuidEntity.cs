using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachzilla.Model.Shared
{
    public abstract class AGuidEntity
    {
        [Key]
        public Guid ID { get; set; }

        public void SetGuid()
        {
            ID = Guid.NewGuid();
        }
        public bool IsNew => ID == Guid.Empty;

    }
}
