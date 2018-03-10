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
        public string LoginPost(LoginInfo loginInfo)
        {
            return "success";
        }

        public ViewResult Register(RegisterInfo registerInfo)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPost(RegisterInfo registerInfo)
        {
            
            return RedirectToAction("Index");
        }
    }
}