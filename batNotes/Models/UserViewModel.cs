using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }


        public string UserName { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Password { get; set; }


        public string Name { get; set; }

    }
}