using batNotes.Models;
using batNotes.Models.Repositories;
using batNotes.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batNotes.Controllers
{
    public class NotesController : BaseController
    {
        private NotesMethods notesMethods;
        private FileMethods fileMethods;

        public NotesController(NotesMethods notesMethods ,UserMethods userRepository, FileMethods fileMethods) : base(userRepository)
        {
            this.notesMethods = notesMethods;
            this.fileMethods = fileMethods;
        }

        // GET: Notes
        public ActionResult ShowNotes(NotesFilter filter, FetchOptions options)
        {
            var model = new NotesListViewModel
            {
                Notes = notesMethods.GetUsersNotes(CurrentUser, filter, options)
        };
            return View(model);
        }
        public ActionResult ViewNote(long id)
        {
            var note = notesMethods.Load(id);
            return View(new NoteViewModel
            {NoteId = note.NoteId,
                Name = note.Name,
                Text = note.Text,
                Changed = note.Changed,
                Created=note.Changed
            });
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EditNoteModel model)
        {
            var file = new File()
            {
                Name = model.File.FileName,
                Content = model.File.InputStream.ToByteArray(),
                Type = model.File.ContentType
            };

            fileMethods.Save(file);
             Note newNote = new Note
                {
                    Name = model.Name,
                    Text = model.Text,
                    Created = DateTime.Now,
                    Changed = DateTime.Now,
                    Author = CurrentUser,
                    File = file
                };
         
           
                notesMethods.Save(newNote);

                return RedirectToAction("ShowNotes", "Notes");
        }
 
        public ActionResult Edit(long id)
        {
            var note = notesMethods.Load(id);
            var model = new EditNoteModel
            { NoteId = note.NoteId,
                Name = note.Name,
                Text = note.Text,
                Changed = note.Changed,
                Created = note.Created,
               
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditNoteModel model)
        {
            var note = notesMethods.Load(model.NoteId);
            note.Name = model.Name;
            note.Text = model.Text;
            note.Changed = DateTime.Now;
            notesMethods.Save(note);
            return RedirectToAction("ShowNotes", "Notes");
        }
       //public ActionResult GetFile(long id, EditNoteModel model)
       // {
       //    var v = notesMethods.Load(id);
       //     model.File = ;
       //     model.File.SaveAs(model.File.FileName);
       //     return RedirectToAction("ShowNotes", "Notes");
       // }
       public FileContentResult GetFile(long id)
        {
          var f = notesMethods.Load(id).File;
            byte[] fileContents = f.Content;
            string contentType = f.Type;
            FileContentResult result = new FileContentResult(fileContents, contentType);
            result.FileDownloadName = f.Name;
            return result;
        }
    }
}