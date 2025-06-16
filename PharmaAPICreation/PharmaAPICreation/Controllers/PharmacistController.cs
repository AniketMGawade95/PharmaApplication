using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        IPharmacist repo;
        public PharmacistController(IPharmacist repo)
        {
            this.repo = repo;   
        }
    }
}
