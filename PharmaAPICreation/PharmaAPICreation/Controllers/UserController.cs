using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser repo;
        public UserController(IUser repo)
        {
            this.repo = repo;   
        }
    }
}
