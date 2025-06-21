using Microsoft.AspNetCore.Mvc;

namespace PharmaAPIConsuming.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
