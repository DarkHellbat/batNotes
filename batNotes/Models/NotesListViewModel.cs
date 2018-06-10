using batNotes.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class NotesListViewModel
    {
       // public User routevalue { get; set; }
        public IList<Note> Notes { get; set; }
        public NotesListViewModel()
        {
            Notes = new List<Note>();
        }
    }
}