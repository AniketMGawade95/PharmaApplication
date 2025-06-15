using Microsoft.AspNetCore.Mvc;

namespace PharmaAPIConsuming.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
