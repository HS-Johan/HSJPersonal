using HSJPersonal.Data;
using HSJPersonal.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace HSJPersonal.Controllers
{
    public class BlogController : Controller
    {
        private readonly HSJPersonalContext _context;

        public BlogController(HSJPersonalContext context)
        {
            _context = context;
        }

        public IActionResult Blog()
        {

            var data = _context.Blog.Select(
                b => new Blog
                {
                    BlogId = b.BlogId,
                    BlogTitle = b.BlogTitle,
                    BlogThumbnail = b.BlogThumbnail,

                    BlogContent = b.BlogContent!=null && b.BlogContent.Length>150
                    ? b.BlogContent.Substring(0, 150)
                    : b.BlogContent
                }
                ).ToList();

            return View(data);
        }

        public IActionResult BlogPage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _context.Blog.FirstOrDefault(johan => johan.BlogId == id);

            return View(blog);
        }

        public IActionResult BlogCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogCreate(Blog blogmodel)
        {
            if (blogmodel.BlogTitle != null)
            {
                _context.Blog.Add(blogmodel);
                _context.SaveChanges();
            }

            return RedirectToAction("BlogList");
        }

        public IActionResult BlogList()
        {
            var data = _context.Blog.Select(
                b => new Blog
                {
                    BlogId = b.BlogId,
                    BlogTitle = b.BlogTitle,
                    BlogThumbnail = b.BlogThumbnail,

                    BlogContent = b.BlogContent!=null && b.BlogContent.Length > 50
                    ? b.BlogContent.Substring(0 , 50) 
                    : b.BlogContent
                }

                ).ToList();



            return View(data);
        }

        public IActionResult BlogEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _context.Blog.FirstOrDefault(johan => johan.BlogId == id);

            return View(blog);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog datamodel)
        {
            if (datamodel.BlogTitle != null)
            {
                _context.Update(datamodel);
                _context.SaveChanges();
            }

            return RedirectToAction("BlogList");
        }

        public IActionResult BlogDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _context.Blog.FirstOrDefault(johan => johan.BlogId == id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Remove(blog);
            _context.SaveChanges();

            return RedirectToAction("BlogList");
        }
    }
}
