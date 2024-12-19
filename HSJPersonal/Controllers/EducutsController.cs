using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HSJPersonal.Controllers
{
    public class EducutsController : Controller
    {
        private readonly HSJPersonalContext _context;

        public EducutsController(HSJPersonalContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
            ViewBag.Slider = new
            {
                Slider1 = "Why do we use it",
                SliderBody1 = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.",
                Slider2 = "Where can I get some",
                SliderBody2 = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form",
                Slider3 = "Where does it come from",
                SliderBody3 = "Contrary to popular belief, Lorem Ipsum is not simply random text."
            };


            ViewBag.Furniture = new
            {
                Title = "Our Furniture",
                Content = "which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't an"
            };

            var products = new List<dynamic>
            {
                new {Name="Brown Chair Design",Price= 100.00, Picture ="f1.png"},
                new {Name="Modern Sofa",Price= 250.00,Picture ="f2.png" },
                new {Name="Wooden Table",Price= 320.00, Picture ="f3.png"},
                new {Name="Student Table",Price= 520.00, Picture ="f4.png"},
                new {Name="Blue Chair Design",Price= 200.00, Picture ="f5.png"},
                new {Name="Double Bed Design",Price= 870.00, Picture ="f6.png"},
            };

            ViewData["ProductList"] = products;

            ViewBag.AboutUs = "The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";

            var blogs = new List<dynamic>
            {
                new {Title="1914 translation by H. Rackham",Content= "The point of using Lorem Ipsum is that it has a more-or-less normal distribution", Picture ="b1.jpg"},
                new {Title="The standard Lorem Ipsum passage",Content= "Duis aute irure dolor in reprehenderit in sunt in culpa qui officia deserunt laborum.", Picture ="b2.jpg"},
                new {Title="Cicero in 45 BC",Content= "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", Picture ="b3.jpg"},
            };

            ViewData["BlogtList"] = blogs;
            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactSubmit(Contact datamodel)
        {
            if( datamodel.PhoneNumber != null && datamodel.Email != null && datamodel.Name != null )
            {
                _context.Add(datamodel);
                _context.SaveChanges();
            }
                        
            return RedirectToAction("Contactus");
        }

        public IActionResult ContactList()
        {
            var data = _context.Contact.ToList();

            return View(data);
        }

        public IActionResult ContactEdit(int? id)
        {
            if( id == null )
            {
                return NotFound();
            }

            var contact = _context.Contact.Find(id);

            return View();
        }


    }
}
