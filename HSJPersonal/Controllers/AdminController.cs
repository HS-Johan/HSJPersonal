using Microsoft.AspNetCore.Mvc;

namespace HSJPersonal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
