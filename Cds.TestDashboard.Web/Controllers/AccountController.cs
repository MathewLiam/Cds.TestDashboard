using Microsoft.AspNetCore.Mvc;

namespace Cds.TestDashboard.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(object registerModel)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
