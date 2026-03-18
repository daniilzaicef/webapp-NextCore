using Microsoft.AspNetCore.Mvc;

namespace WebApp_NextCore.Controllers
{
    public class BlogController : Controller
    {
        //Список статей 
        public IActionResult Index()
        {
            return View();
        }

        //Страница чтения статьи
        public IActionResult Arcticle()
        {
            return View();
        }
    }
}
