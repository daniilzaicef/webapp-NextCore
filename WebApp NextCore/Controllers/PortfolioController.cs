using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;

namespace WebApp_NextCore.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Галерея выполненных проектов с фильтрацией по технологиям
        public IActionResult Index(string search)
        {
            var projects = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                projects = projects.Where(p =>
                    p.Title.Contains(search) ||
                    p.Description.Contains(search));
            }

            return View(projects.ToList());
        }

        public IActionResult Details(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            return View(project);
        }
    }
}
