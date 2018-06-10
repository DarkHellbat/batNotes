using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batNotes.Models
{
   public class Permission
    {
        public virtual long PermissionID { get; set; }
        public virtual int PermissionLevel { get; set; }
        public virtual string Description { get; set; }
    }
}
