using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            if (ModelState.IsValid)
            {
                _context.Vacancy.Add(vacancy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(vacancy);
        }

        [HttpGet]
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


        [Authorize(Roles = "Admin")]
        public IActionResult Response()
        {
            var responses = _context.VacancyResponses
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(responses);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteResponse(int id)
        {
            var response = _context.VacancyResponses.Find(id);
            if (response == null) return NotFound();

            _context.VacancyResponses.Remove(response);
            _context.SaveChanges();

            return RedirectToAction("Response");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Projects()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProject(ProjectModel project, IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Portfolio", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                project.ImagePath = fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
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
        public async Task<IActionResult> EditProject(ProjectModel project, IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Portfolio", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                project.ImagePath = fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
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

        [Authorize(Roles = "Admin")]
        public IActionResult Service()
        {
            var services = _context.Services;
            return View(services);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateService(ServiceModel service, IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/service", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                service.IamgePath = fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();

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
        public async Task<IActionResult> EditService(ServiceModel service, IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/service", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                service.IamgePath = fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
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

        [Authorize(Roles = "Admin")]
        public IActionResult Blog()
        {
            var posts = _context.BlogPosts
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(BlogPost post, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    post.ImagePath = fileName;
                }

                post.CreatedAt = DateTime.Now;

                _context.BlogPosts.Add(post);
                await _context.SaveChangesAsync();

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(BlogPost model, IFormFile image)
        {
            var post = _context.BlogPosts.Find(model.Id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
                post.ShortDescription = model.ShortDescription;

                await _context.SaveChangesAsync();
            }

            _context.BlogPosts.Update(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Blog));
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

        [HttpPost]
        public IActionResult UpdateStatus([FromBody] UpdateStatusModel model)
        {
            var request = _context.ServiceRequests.Find(model.Id);

            if (request != null)
            {
                request.Status = model.Status;
                _context.SaveChanges();
            }

            return Ok();
        }

        public IActionResult Feedback()
        {
            var messages = _context.FeedbacksMessage
                .OrderByDescending(m => m.Id)
                .ToList();

            return View(messages);
        }

        public IActionResult DeleteFeedback(int id)
        {
            var message = _context.FeedbacksMessage.Find(id);

            if (message != null)
            {
                _context.FeedbacksMessage.Remove(message);
                _context.SaveChanges();
            }

            return RedirectToAction("Feedback");
        }


    }
}
