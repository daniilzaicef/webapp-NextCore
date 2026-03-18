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
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
        //Подробное описание конкретной услуги с кейсами и ценами.
        public IActionResult Details()
        {
            return View();
        }
    }
}
