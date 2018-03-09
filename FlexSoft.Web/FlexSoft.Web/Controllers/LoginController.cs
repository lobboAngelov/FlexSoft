using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlexSoft.Web.Models;

namespace FlexSoft.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new LoginInfo());
        }

        [HttpPost]
        public ActionResult Login(LoginInfo loginInfo)
        {

            return View();
        }
    }
}