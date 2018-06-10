using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class CreateUserModel
    {
        [Display(Name = "Логин")]
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Фамилия")]

        public string LastName { get; set; }
        [Display(Name = "Имя")]

        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        public File Avatar { get; set; }

        [Required]
        public string Email { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateofBirth { get; set; }
        [Display(Name = "Статус")]
        public Enum Status { get; set; }
    }
}