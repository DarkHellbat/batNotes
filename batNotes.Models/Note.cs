using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batNotes.Models
{
    public class Note
    {
        public virtual long NoteId { get; set; }
        public virtual string Text { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Changed { get; set; }
        public virtual User Author { get; set; }
        public virtual File File { get; set; }
    }
}
