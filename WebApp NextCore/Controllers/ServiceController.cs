using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;

namespace WebApp_NextCore.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Список всех направлений 
        public IActionResult Index(string search)
        {
            var services = _context.Services.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                services = services.Where(s =>
                    s.Title.Contains(search) ||
                    s.Description.Contains(search));
            }

            return View(services.ToList());
        }
        //Подробное описание конкретной услуги с кейсами и ценами.
        public IActionResult Details(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }
    }
}
