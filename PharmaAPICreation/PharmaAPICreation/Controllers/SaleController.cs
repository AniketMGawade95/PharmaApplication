//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PharmaAPICreation.DTO;
//using PharmaAPICreation.Repo;

//namespace PharmaAPICreation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SaleController : ControllerBase
//    {
//        private readonly SaleRepo repo;

//        public SaleController(SaleRepo repo)
//        {
//            this.repo = repo;
//        }

//        [HttpPost("Add")]
//        public IActionResult AddSale(SaleDTO dto)
//        {
//            repo.AddSale(dto);
//            return Ok("Sale created successfully!");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Services;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly SaleService service;

        public SaleController(SaleService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddSale([FromBody] SaleDTO dto)
        {
            try
            {
                service.AddSale(dto);
                return Ok(new { message = "Sale added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SaleDTO> GetSale(int id)
        {
            var sale = service.GetSale(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }
    }
}
