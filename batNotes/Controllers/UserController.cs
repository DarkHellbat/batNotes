using batNotes.Auth;
using batNotes.Models;
using batNotes.Models.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batNotes.Controllers
{
    public class UserController : BaseController
    {
        public UserController(UserMethods userRepository) :
           base(userRepository)
        {
            this.userRepository = userRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            var model = new UserListViewModel
            {
                Users = userRepository.GetAll()
            };

            return View(model);
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User { UserName = model.UserName, FirstName = model.FirstName, SecondName = model.SecondName, LastName = model.LastName, Status = Status.Active };
                if (CurrentUser == null || CurrentUser.Permission.PermissionLevel == 2)
                {
                    newUser.Permission.PermissionID = 2; //вот хз, будет ли работать
                }
                    var result = UserManager.CreateAsync(newUser, model.Password);
                if (!result.Result.Succeeded)
                {
                    foreach (var er in result.Result.Errors)
                    {
                        ModelState.AddModelError("", er);
                    }
                }
         
                if(CurrentUser!=null)
                return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Проверьте правильность введенных данных");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            var user = userRepository.Load(model.Id);
            user.DateofBirth = Convert.ToDateTime(model.DateofBirth);
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.SecondName = model.SecondName;
            user.UserName = model.UserName;
            userRepository.Change(user);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(long id)
        {
            var user = userRepository.Load(id);
            return View(new EditUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                SecondName = user.SecondName,
                DateofBirth=user.DateofBirth,
                Email=user.Email
            });
        }
    }
}