using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;

namespace WebApp_NextCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(FeedbackMessage model)
        {
            if (ModelState.IsValid)
            {
                _context.FeedbacksMessage.Add(model);
                _context.SaveChanges();
                TempData["Message"] = "Спасибо! Ваше сообщение отправлено.";
                ModelState.Clear();//чтобы очистить форму
                return RedirectToAction("Contact");
            }
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
