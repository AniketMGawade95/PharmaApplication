using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepo repo;
        private readonly IMapper mapper;

        public PurchaseController(IPurchaseRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseReadDTO>> GetAll()
        {
            var purchases = repo.GetAll();
            var result = mapper.Map<IEnumerable<PurchaseReadDTO>>(purchases);
            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult<PurchaseReadDTO> GetById(int id)
        {
            var purchase = repo.GetById(id);
            if (purchase == null)
                return NotFound();
            var result = mapper.Map<PurchaseReadDTO>(purchase);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(PurchaseCreateDTO dto)
        {
            var purchase = mapper.Map<Purchase>(dto);
            repo.Add(purchase);
            return Ok("Purchase created successfully");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, PurchaseCreateDTO dto)
        {
            var data = repo.GetById(id);
            if (data == null)
                return NotFound();

            mapper.Map(dto, data);
            data.UpdatedAt = DateTime.Now;
            repo.Update(data);

            return Ok("Purchase updated successfully" );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok( "Purchase deleted successfully" );
        }
    }


}

