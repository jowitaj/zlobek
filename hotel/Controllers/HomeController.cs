using Microsoft.AspNetCore.Mvc;

namespace hotel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
