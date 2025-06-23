using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PharmaAPIConsuming.DTO;
using PharmaAPIConsuming.Models;
using System.Text;

namespace PharmaAPIConsuming.Controllers
{
    public class PurchaseItemController : Controller
    {
        HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            List<PurchaseItemReadDTO> data = new List<PurchaseItemReadDTO>();
            var response = client.GetAsync("https://localhost:7135/api/PurchaseItem").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<PurchaseItemReadDTO>>(json);
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Add(PurchaseItemCreateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7135/api/PurchaseItem", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            LoadDropdowns();
            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PurchaseItemUpdateDTO dto = new PurchaseItemUpdateDTO();
            var response = client.GetAsync("https://localhost:7135/api/PurchaseItem/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<PurchaseItemReadDTO>(json);
                if (obj != null)
                {
                    dto.MedicineId = obj.MedicineId;
                    dto.BranchId = obj.BranchId;
                    dto.Quantity = obj.Quantity;
                    dto.PurchasePrice = obj.PurchasePrice;
                    dto.SellingPrice = obj.SellingPrice;
                }
            }

            LoadDropdowns(dto.MedicineId, dto.BranchId);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(int id, PurchaseItemUpdateDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PutAsync("https://localhost:7135/api/PurchaseItem/" + id, content).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            LoadDropdowns(dto.MedicineId, dto.BranchId);
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync("https://localhost:7135/api/PurchaseItem/" + id).Result;

            return Content("<script>alert('Deleted successfully'); window.location.href='/PurchaseItem/Index';</script>", "text/html");
        }

        private void LoadDropdowns(int selectedMedId = 0, int selectedBranchId = 0)
        {
            // Medicines
            var medicineResponse = client.GetAsync("https://localhost:7135/api/Medicine/GetAllMed").Result;
            if (medicineResponse.IsSuccessStatusCode)
            {
                var json = medicineResponse.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<MedicineReadDTO>>(json);
                ViewBag.Medicine= new SelectList(list, "MedicineId", "Name", selectedMedId);
            }

            // Branches
            var branchResponse = client.GetAsync("https://localhost:7135/api/Admin/FetchBranches").Result;
            if (branchResponse.IsSuccessStatusCode)
            {
                var json = branchResponse.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<BranchDTO>>(json);
                ViewBag.Branch = new SelectList(list, "BranchId", "BranchName", selectedBranchId);
            }
        }
    }
}
