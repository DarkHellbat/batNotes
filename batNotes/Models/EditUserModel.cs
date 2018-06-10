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
        [Display(Name = "Логин")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Фамилия")]
        public  string LastName { get; set; }
        [Display(Name = "Имя")]
        public  string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public  string SecondName { get; set; }
        public  File Avatar { get; set; }

        public  string Email { get; set; }
        [Display(Name = "Дата рождения")]
        public  DateTime DateofBirth { get; set; }
        [Display(Name = "Статус")]
        public Status Status { get; set; }
    }
}