using Microsoft.AspNetCore.Mvc;

namespace HandsOnTestGoDigital.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
