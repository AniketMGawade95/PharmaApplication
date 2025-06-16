using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdmin repo;
        public AdminController(IAdmin repo)
        {
            this.repo=repo;
        }


        [HttpPost]
        [Route("AddRoles")]
        public IActionResult AddRoles(AddRolesDTO dto)
        {

            var data = new Role
            {
                RoleName = dto.RoleName,
            };


            if (data != null)
            {
                repo.AddRoles(data);
                return Ok("Role Added Succesfully");
            }
            else
            {
                return NotFound("Role Not Added");
            }

           
        }
        [HttpPost]
        [Route("AddBranches")]
        public IActionResult AddBranches(AddBranchesDTO dto)
        {

            var data = new Branch
            {
                BranchName = dto.BranchName,
                BranchAddress = dto.BranchAddress,
            };


            if (data != null)
            {
                repo.AddBranches(data);
                return Ok("Branch Added Succesfully");
            }
            else
            {
                return NotFound("Branch Not Added");
            }

           
        }



    }
}
