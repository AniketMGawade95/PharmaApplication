using Microsoft.AspNetCore.Mvc;

namespace PharmaAPICreation.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
