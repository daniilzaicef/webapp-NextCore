using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_NextCore.Data;
using WebApp_NextCore.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp_NextCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vacancies = _context.Vacancy;
            return View(vacancies);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VacancyModel vacancy)
        {
            if(ModelState.IsValid)
            {
                _context.Vacancy.Add(vacancy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(vacancy);
        }

        //Редактирование списка услуг.
        public IActionResult Edit(int id)
        {
            var vacancy = _context.Vacancy.Find(id);
            return View(vacancy);
        }

        [HttpPost]
        public IActionResult Edit(VacancyModel vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Vacancy.Update(vacancy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancy);
        }

        public IActionResult Delete(int id)
        {
            var vacancy = _context.Vacancy.Find(id);
            _context.Vacancy.Remove(vacancy);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles ="Admin")]
        public IActionResult Response()
        {
            var responses = _context.VacancyResponses
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(responses);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult DeleteResponse(int id)
        {
            var response = _context.VacancyResponses.Find(id);
            if (response == null) return NotFound();

            _context.VacancyResponses.Remove(response);
            _context.SaveChanges();

            return RedirectToAction("Response");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Projects()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateProject(ProjectModel project)
        {
            if(ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Projects));
            }
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditProject(int id)
        {
            var project = _context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditProject(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Projects));
            }
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Projects));
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Service()
        {
            var services = _context.Services;
            return View(services);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateService(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Service));
            }

            return View(service);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditService(int id)
        {
            var service = _context.Services.Find(id);
            return View(service);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditService(ServiceModel service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction(nameof(Service));
            }

            return View(service);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);

            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Service));
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Blog()
        {
            var posts = _context.BlogPosts
                .OrderByDescending(x=>x.CreatedAt)
                .ToList();

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult CreatePost(BlogPost post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;

                _context.BlogPosts.Add(post);
                _context.SaveChanges();

                return RedirectToAction(nameof(Blog));
            }
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditPost(int id)
        {
            var post = _context.BlogPosts.Find(id);
            return View(post);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditPost(BlogPost post)
        {
            if (ModelState.IsValid)
            {
                _context.BlogPosts.Update(post);
                _context.SaveChanges();

                return RedirectToAction(nameof(Blog));
            }

            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int id)
        {
            var post = _context.BlogPosts.Find(id);

            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Blog));
        }

        public IActionResult Requests()
        {
            var requests = _context.ServiceRequests
                .Include(r => r.Service)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRequest(int id)
        {
            var request = _context.ServiceRequests.Find(id);

            if (request != null)
            {
                _context.ServiceRequests.Remove(request);
                _context.SaveChanges();
            }

            return RedirectToAction("Requests");
        }
    }
}
