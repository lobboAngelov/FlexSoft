using System.Web.Mvc;

namespace FlexSoft.Web.Controllers
{
    [Authorize]
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}