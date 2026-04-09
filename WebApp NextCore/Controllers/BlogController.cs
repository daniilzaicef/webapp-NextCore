using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;

namespace WebApp_NextCore.Controllers
{
    public class BlogController : Controller
    {
        //Список статей 
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var posts = _context.BlogPosts.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                posts = posts.Where(p =>
                    p.Title.Contains(search) ||
                    p.Content.Contains(search));
            }

            return View(posts.ToList());
        }

        //Страница чтения статьи
        public IActionResult Details(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(x => x.Id == id);

            if(post == null)
                return NotFound();
            return View(post);
        }        
    }
}
