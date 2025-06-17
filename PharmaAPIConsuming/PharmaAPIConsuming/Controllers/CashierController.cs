using Microsoft.AspNetCore.Mvc;

namespace PharmaAPIConsuming.Controllers
{
    public class CashierController : Controller
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
