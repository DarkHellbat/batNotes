using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class NoteViewModel
    {
        public long NoteId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
      //  public virtual User Author { get; set; }
       public HttpPostedFileBase File { get; set; }
    }
}