using HSJPersonal.Data;
using HSJPersonal.DataModels;
using HSJPersonal.ViewModel;
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
                Title = "Our Product",
                Content = "which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't an"
            };
            
            ViewBag.AboutUs = "The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";


            //ViewModel

            var AllData = new HomePageVM();

            AllData.blogs = _context.Blog.Select(
                b => new Blog
                {
                    BlogId = b.BlogId,
                    BlogTitle = b.BlogTitle,
                    BlogThumbnail = b.BlogThumbnail,

                    BlogContent = b.BlogContent != null && b.BlogContent.Length > 150
                    ? b.BlogContent.Substring(0, 150)
                    : b.BlogContent
                }
                ).Take(3).ToList();

            AllData.products = _context.products.Where(obj => obj.IsActive == true && obj.ProductAmmount > 0 ).Take(3).ToList();

            return View(AllData);
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

            var contact = _context.Contact.FirstOrDefault( johan => johan.Id == id );

            return View(contact);
        }

        [HttpPost]
        public IActionResult ContactEdit(Contact datamodel)
        {
            if (datamodel.PhoneNumber != null && datamodel.Email != null && datamodel.Name != null)
            {
                _context.Update(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("ContactList");
        }

        public IActionResult ContactDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contact.FirstOrDefault(johan => johan.Id == id);

            if( contact == null )
            {
                return NotFound();
            }

            _context.Remove(contact);
            _context.SaveChanges();

            return RedirectToAction("ContactList");
        }

        public IActionResult About()
        {
            ViewBag.AboutUs = "The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";

            return View();
        }

        public IActionResult Blog()
        {
            var blogs = new List<dynamic>
            {
                new {Title="1914 translation by H. Rackham",Content= "The point of using Lorem Ipsum is that it has a more-or-less normal distribution", Picture ="b1.jpg"},
                new {Title="The standard Lorem Ipsum passage",Content= "Duis aute irure dolor in reprehenderit in sunt in culpa qui officia deserunt laborum.", Picture ="b2.jpg"},
                new {Title="Cicero in 45 BC",Content= "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", Picture ="b3.jpg"},
            };

            ViewData["BlogtList"] = blogs;

            return View();
        }

        public IActionResult Product()
        {
            ViewBag.Furniture = new
            {
                Title = "Our Product",
                Content = "which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't an"
            };

            var data = _context.products.Where(obj => obj.IsActive == true && obj.ProductAmmount > 0).ToList();

            return View(data);
        }

    }
}
