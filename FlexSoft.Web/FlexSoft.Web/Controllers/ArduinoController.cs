using System.Linq;
using System.Web.Mvc;
using FlexSoft.Infrastructure;
using FlexSoft.Infrastructure.Entites;
using FlexSoft.Services.Abstract;

namespace FlexSoft.Web.Controllers
{
    public class ArduinoController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IRepository _repository;

        public ArduinoController(IUserManager userManager, IRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public JsonResult Authenticate(int rfId, int deviceId)
        {
            var user = _userManager.GetUser(rfId);
            
            if (user == null || _repository.GetAll<ArduinoDevice>().Any(x=> x.ArduinoDeviceId == deviceId))
            {
                return Json(new { fail = true });
            }

            return Json(new { });
        }
    }
}