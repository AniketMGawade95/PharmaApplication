using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Services;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Repo.IUser repo;
        public UserController(Repo.IUser repo)
        {
            this.repo = repo;   
        }
    }
}
