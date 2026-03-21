using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;

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

        public IActionResult Index()
        {
            var posts = _context.BlogPosts
                .OrderBy(x => x.CreatedAt)
                .ToList();
            return View(posts);
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
