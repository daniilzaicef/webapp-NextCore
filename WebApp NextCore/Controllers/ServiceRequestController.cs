using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;

namespace WebApp_NextCore.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IActionResult Create(int serviceId)
        {
            var request = new ServiceRequest
            {
                ServiceId = serviceId
            };

            return View(request);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Add(request);
                _context.SaveChanges();

                TempData["Success"] = "Заявка отправлена!";
                return RedirectToAction("Index", "Service");
            }
            return View(request);
        }
    }
}
