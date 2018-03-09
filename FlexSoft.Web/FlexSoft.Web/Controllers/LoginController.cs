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

        public ViewResult Register()
        {
            return View();
        }

        public ActionResult Register(LoginInfo loginInfo)
        {
            
            return View();
        }
    }
}