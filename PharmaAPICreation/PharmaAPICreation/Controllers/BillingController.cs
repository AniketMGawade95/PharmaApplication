using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        BillingRepo repo;
        public BillingController(BillingRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer(CustomerDTO dto)
        {
            repo.AddCustomer(dto);
            return Ok("Added!!!");
        }

        [HttpGet]
        [Route("AllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var data=repo.GetAllCustomers();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCustomer/{id}")]
        public IActionResult SelectCustomer(int id)
        {
            var data = repo.SelectCustomer(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            repo.DeleteCustomer(id);
            return Ok("Deleted!!!");
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomerDTO dto)
        {
            repo.UpdateCustomer(dto);
            return Ok("Updated!!!");
        }
    }
}
