using batNotes.Models;
using batNotes.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batNotes.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserMethods userRepository) :
            base(userRepository)
        {
        }

        // GET: Home
        public ActionResult Index(HomeViewModel model)
        {
            if (CurrentUser.UserName == "admin")
                model.LoggedAs = Permission.Admin;
            else
                model.LoggedAs = Permission.CommonUser;
            return View(model);
        }
    }
}