using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HSJPersonal.Controllers
{
    public class AdminController : Controller
    {
        private readonly HSJPersonalContext _context;

        public AdminController(HSJPersonalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSubmit(Admin datamodel)
        {
            if( datamodel.AdminName!=null && datamodel.AdminPhone!=null && datamodel.AdminEmail!=null && datamodel.AdminLocation!=null && datamodel.AdminAboutUs!=null )
            {
                _context.Add(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("AdminInfo");
        }

        public IActionResult AdminInfo()
        {
            var data = _context.Admin.FirstOrDefault(johan => johan.AdminId == 1);

            return View(data);
        }

        public IActionResult AdminEdit()
        {
            var data = _context.Admin.FirstOrDefault(johan => johan.AdminId == 1);

            return View(data);
        }

        [HttpPost]
        public IActionResult AdminEdit(Admin datamodel)
        {
            if (datamodel.AdminName != null && datamodel.AdminPhone != null && datamodel.AdminEmail != null && datamodel.AdminLocation != null && datamodel.AdminAboutUs != null)
            {
                _context.Update(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("AdminInfo");
        }

    }
}
