using Microsoft.AspNetCore.Mvc;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;
using WebApp_NextCore.ViewModel;

namespace WebApp_NextCore.Controllers
{
    public class CareersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Список открытых вакансий.
        public IActionResult Index()
        {
            var vacancies = _context.Vacancy.ToList();
            return View(vacancies);
        }

        public IActionResult Apply(int id)
        {
            var vacancy = _context.Vacancy.Find(id);
            if(vacancy == null) return NotFound();

            var model = new VacancyResponseViewModel
            {
                VacancyTitle = vacancy.Title
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Apply(VacancyResponseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new VacancyResponse
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Message = model.Message,
                    VacancyTitle = model.VacancyTitle,
                    CreatedAt = DateTime.Now
                };

                _context.VacancyResponses.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Thanks");
            }

            return View(model);
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
