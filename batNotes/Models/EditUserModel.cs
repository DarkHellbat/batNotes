using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class EditUserModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual File Avatar { get; set; }
        [Required]
        public virtual string Email { get; set; }
        public virtual DateTime DateofBirth { get; set; }
        public virtual Enum Status { get; set; }
    }
}