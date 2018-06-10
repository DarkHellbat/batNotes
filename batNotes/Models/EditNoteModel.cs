using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace batNotes.Models
{
    public class EditNoteModel
    {
        public long NoteId { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Текст заметки")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime Created { get; set; }
        [Display(Name = "Дата изменения")]
        public DateTime Changed { get; set; }
        [Display(Name = "Файл")]
        public HttpPostedFileBase File { get; set; }
    }
}