using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HSJPersonal.Controllers
{
    public class ProductController : Controller
    {
        private readonly HSJPersonalContext _context;

        public ProductController(HSJPersonalContext context)
        {
            _context = context;
        }

        public IActionResult ProductForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductSubmit(Product datamodel)
        {
            if( datamodel.ProductName != null )
            {
                _context.Add(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("ProductForm");
        }

    }
}
