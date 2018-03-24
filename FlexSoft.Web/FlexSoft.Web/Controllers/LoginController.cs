using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using FlexSoft.Infrastructure.Entites.WebModels;
using FlexSoft.Services.Abstract;
using FlexSoft.Web.Extensions;

namespace FlexSoft.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager _userManager;

        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        public ActionResult Index()
        {
            return View(new LoginInfo());
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInfo loginInfo)
        {
            var result = await _userManager.Authorise(loginInfo.Username, loginInfo.Password);
            
            if (!result.Fail)
            {
                Session.SetUser(result.User);
                FormsAuthentication.SetAuthCookie(loginInfo.Username,false);
                return RedirectToAction("ViewProfile", "Profile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return View("Index", new LoginInfo());
        }

        public ViewResult Register()
        {
            return View(new RegisterInfo());
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPost(RegisterInfo registerInfo)
        {
            var result = await _userManager.Register(registerInfo);

            if (!result.Fail)
            {
                return View("Index",new LoginInfo
                {
                    Username = registerInfo.Email
                });
               
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View("Register");
        }
    }
}