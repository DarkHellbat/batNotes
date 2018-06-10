using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batNotes.Models
{
   public class File
    {
        public virtual long FileId { get; set; }
        public virtual byte[] Content { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        
    }
}
