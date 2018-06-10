using batNotes.Auth;
using batNotes.Models;
using batNotes.Models.Mappings;
using batNotes.Models.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batNotes.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserMethods userRepository) :
              base(userRepository)
        {

        }

        public ActionResult Login()
        {
            if (userRepository.FindByLogin("admin") == null)
            {
                CreateUser("admin", "123456");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.FindByLogin(model.UserName);
                if (user.Status == Status.Active)
                {
                    var result = SignInManager.PasswordSignIn(model.UserName, model.Password, false, false);
                    if (result == SignInStatus.Success)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   else
                    {
                        ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                    } 
                }
                else
            {
                ModelState.AddModelError("", "Учетная запись заблокирована");
            }
                
               
            }
            return View(model);

        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult CreateUser(string Login, string Password)
        {
            var user = new User { UserName = Login };
            var result = UserManager.CreateAsync(user, Password);
            if (result.Result.Succeeded)
            {
               user = userRepository.Load(1);
                user.Permission = Permission.Admin;
                user.Status = Status.Active;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Result.Errors)
                {
                    ModelState.AddModelError("", "");
                }
                return RedirectToAction("Index", "Home");
            }

        }
    }
}