using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;

namespace WebApp_NextCore.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceRequestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Create(ServiceRequest model)
        {
            var user = await _userManager.GetUserAsync(User);

            model.UseId = user.Id;
            model.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Service");
            }

            return View(new ServiceRequest());
        }
    }
}
