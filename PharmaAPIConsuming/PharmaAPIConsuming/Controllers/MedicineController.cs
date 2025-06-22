using Microsoft.AspNetCore.Mvc;
using PharmaAPIConsuming.DTO;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PharmaAPIConsuming.Controllers
{
    public class MedicineController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly string baseurl= "https://localhost:7135/api/Medicine/";

        public MedicineController()
        {
            httpClient = new HttpClient();
        }

        // to get all medicine
        public IActionResult Index()
        {
            var medicines = httpClient.GetFromJsonAsync<List<MedicineReadDTO>>(baseurl+ "GetAllMed").Result;
            return View(medicines);
        }

        // JSON for AJAX
        [HttpGet]
        public IActionResult GetAllMedicine()
        {
            var medicines = httpClient.GetFromJsonAsync<List<MedicineReadDTO>>(baseurl + "GetAllMed").Result;
            return Json(medicines);
        }

        // to get single medicine for edit
        public IActionResult GetMedicineById(int id)
        {
            var medicine = httpClient.GetFromJsonAsync<MedicineReadDTO>(baseurl + $"GetMed{id}").Result;
            return Json(medicine);
        }

        // to add medicine
        [HttpPost]
        public IActionResult AddMedicine(MedicineCreateDTO dto)
        {
            dto.CreatedAt= DateTime.Now;
            dto.CreatedBy = "Admin";
            httpClient.PostAsJsonAsync(baseurl+ "AddMed", dto).Wait();
            return Ok("Medcine Added Sucessfully");
        }

        // to update
        //[HttpPut("UpdateMedicine/{id}")]
        //public IActionResult UpdateMedicine(int id,MedicineUpdateDTO dto)
        //{
        //    dto.UpdatedBy = "Admin";
        //    dto.UpdatedAt = DateTime.Now;
        //    httpClient.PutAsJsonAsync(baseurl + $"UpdateMed{id}", dto).Wait();
        //    return Ok("Medicine Updated SucessFully");
        //}
        [HttpPost]
        public IActionResult UpdateMedicine(MedicineUpdateDTO dto)
        {
            dto.UpdatedAt = DateTime.Now;
            dto.UpdatedBy = "Admin";
            var response = httpClient.PutAsJsonAsync(baseurl + $"UpdateMed{dto.MedicineId}", dto).Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok("Medicine Updated Successfully");
            }
            else
            {
                return BadRequest("Update Failed");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMedicine(int id)
        {
            httpClient.DeleteAsync(baseurl + $"DeleteMed{id}").Wait();
            return Ok("Medicine Deleted Sucessfully");
        }
    }
}
