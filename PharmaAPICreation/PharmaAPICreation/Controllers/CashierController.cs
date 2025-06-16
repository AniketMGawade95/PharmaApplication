using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        ICashier repo;
        public CashierController(ICashier repo)
        {
            this.repo = repo;
        }
    }
}
