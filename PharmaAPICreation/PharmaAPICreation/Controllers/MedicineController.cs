using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;
using System.Net.Http;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        public readonly IMapper mapper;
        public readonly IMedicineRepository medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository,IMapper mapper)
        {
            this.mapper = mapper;
            this.medicineRepository = medicineRepository;
        }

        [HttpGet]
        [Route("GetAllMed")]
        public IActionResult GetAll()
        {
            var medicineList = medicineRepository.GetAllMedicines(); // source is Model
            var data = mapper.Map<List<MedicineReadDTO>>(medicineList); // Target is MedicineReadDTO
            return Ok(data);
        }

        [HttpGet]
        [Route("GetMed{id}")]
        public IActionResult Get(int id)
        {
            var medicine = medicineRepository.GetMedicineById(id); //soucre is Model
            if (medicine == null) return NotFound("Medicine not found");
            var dto = mapper.Map<MedicineReadDTO>(medicine); // Target is MedicineReadDTO
            return Ok(dto);
        }

        [HttpPost]
        [Route("AddMed")]
        public IActionResult Create(MedicineCreateDTO dto)
        {
            var data = mapper.Map<Medicine>(dto); //Target is model, source is dto
            data.CreatedAt = DateTime.Now;
            data.CreatedBy = dto.CreatedBy ?? "DefaultUser";
            medicineRepository.AddMedicine(data);
            return Ok("Medicine Added Sucessfully");
        }

        [HttpPut]
        [Route("UpdateMed{id}")]
        public IActionResult Update(int id, MedicineUpdateDTO dto)
        {
            if (id != dto.MedicineId) return BadRequest("Id mismatch");
            var medicine = medicineRepository.GetMedicineById(id);
            if (medicine == null) return NotFound("Medine does not exixts");
            mapper.Map(dto, medicine); // Source is dto, Target is model
            medicine.UpdatedAt = DateTime.Now;
            medicine.UpdatedBy = dto.UpdatedBy ?? "Defaultuser";
            medicineRepository.UpdateMedicine(medicine);
            return Ok("Medicine Updated Sucessfully");
        }

        //[HttpPut]
        //[Route("UpdateMed")] // change route
        //public IActionResult UpdateMedicine([FromBody] MedicineUpdateDTO dto)
        //{
        //    var id = dto.MedicineId;
        //    var medicine = medicineRepository.GetMedicineById(id);
        //    if (medicine == null) return NotFound("Not found");

        //    mapper.Map(dto, medicine);
        //    medicine.UpdatedAt = DateTime.Now;
        //    medicine.UpdatedBy = dto.UpdatedBy ?? "Defaultuser";
        //    medicineRepository.UpdateMedicine(medicine);
        //    return Ok("Medicine Updated");
        //}

        [HttpDelete]
        [Route("DeleteMed{id}")]
        public IActionResult Delete(int id)
        {
            var medicine = medicineRepository.GetMedicineById(id);
            if (medicine == null) return NotFound("Medicine not found");
            medicineRepository.DeleteMedicine(id);
            return Ok("Medicine deleted Sucessfully");
        }
    }
}
