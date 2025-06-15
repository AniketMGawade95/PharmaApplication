using Microsoft.AspNetCore.Mvc;

namespace PharmaAPIConsuming.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
