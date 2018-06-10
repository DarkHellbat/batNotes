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
    public class BaseController : Controller
    {
        protected UserMethods userRepository;

        public BaseController(UserMethods userRepository)
        {
            this.userRepository = userRepository;
        }

        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public User CurrentUser
        {
            get
            {
                return userRepository.GetCurrentUser(User);
            }
        }
     
    }
}