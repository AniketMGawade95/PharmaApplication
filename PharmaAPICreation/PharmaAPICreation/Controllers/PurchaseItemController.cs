using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseItemController : ControllerBase
    {

        private readonly IPurchaseItemRepo repo;
        private readonly IMapper mapper;

        public PurchaseItemController(IPurchaseItemRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseItemReadDTO>> GetAll()
        {
            var data = repo.GetAll();
            var result = mapper.Map<IEnumerable<PurchaseItemReadDTO>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PurchaseItemReadDTO> GetById(int id)
        {
            var data = repo.GetById(id);
            if (data == null) return NotFound();

            var result = mapper.Map<PurchaseItemReadDTO>(data);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(PurchaseItemCreateDTO dto)
        {
            var data = mapper.Map<PurchaseItem>(dto);
            repo.Add(data);
            return Ok("PurchaseItem created");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, PurchaseItemUpdateDTO dto)
        {
            var data = repo.GetById(id);
            if (data == null) return NotFound();

            mapper.Map(dto, data);
            data.UpdatedBy = "user"; 
            repo.Update(data);

            return Ok("PurchaseItem updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok("PurchaseItem deleted");
        }
    }
}
