using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class NotesFilter
    {
        public string Name { get; set; }
        public RangeDateTime CreationDate { get; set; }
        public RangeDateTime ChangingDate { get; set; }

        public NotesFilter()
        {
            CreationDate = new RangeDateTime();
            ChangingDate = new RangeDateTime();
    }
    }
}