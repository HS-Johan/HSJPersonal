using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HSJPersonal.Controllers
{
    public class SocialController : Controller
    {
        private readonly HSJPersonalContext _context;

        public SocialController(HSJPersonalContext context)
        {
            _context = context;
        }

        public IActionResult AddSocial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SocialSubmit(Social FormData)
        {
            if (FormData.SocialName != null && FormData.SocialIcon != null && FormData.SocialLink != null)
            {
                _context.Social.Add(FormData);
                _context.SaveChanges();

                return Json(new { success = true, msg = "Data Saved!" });

                //return Json(new { success = true, msg = "Data saved!" });
            }

            return Json(new { success = false, msg = "Not Saved!", sdf = "asdf" });

            //return Json(new { success = false, msg = "not saved!", sdf = "asdf" });
        }

        public IActionResult SocialList()
        {
            var data = _context.Social.ToList();

            return View(data);
        }

        public IActionResult SocialEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = _context.Social.FirstOrDefault(johan => johan.SocialId == id);

            return View(social);
        }

        [HttpPost]
        public IActionResult SocialEdit(Social datamodel)
        {
            if (datamodel.SocialName != null)
            {
                _context.Update(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("SocialList");
        }

        public IActionResult SocialDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = _context.Social.FirstOrDefault(johan => johan.SocialId == id);

            if (social == null)
            {
                return NotFound();
            }

            _context.Remove(social);
            _context.SaveChanges();

            return RedirectToAction("SocialList");
        }

    }
}