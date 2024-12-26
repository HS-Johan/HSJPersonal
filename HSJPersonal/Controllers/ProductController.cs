using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            return RedirectToAction("ProductList");
        }

        public IActionResult ProductList()
        {
            var data = _context.products.ToList();

            return View(data);
        }

        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.products.FirstOrDefault(johan => johan.ProductId == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult ProductEdit(Product datamodel)
        {
            if (datamodel.ProductName != null )
            {
                _context.Update(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("ProductList");
        }

        public IActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.products.FirstOrDefault(johan => johan.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }

    }
}
