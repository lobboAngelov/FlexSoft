using System.Web.Mvc;
using System.Web.Security;
using FlexSoft.Services.Abstract;
using FlexSoft.Web.Extensions;

namespace FlexSoft.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;

        public ProfileController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public ActionResult ViewProfile()
        {
            return View(Session.User());
        }

        public ActionResult EditProfile()
        {
            return View(Session.User());
        }

        public PartialViewResult TrainingSummary()
        {
            
            return PartialView();
        }
    }
}