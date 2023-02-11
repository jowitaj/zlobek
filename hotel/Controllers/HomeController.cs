using Microsoft.AspNetCore.Mvc;

namespace zlobek.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
