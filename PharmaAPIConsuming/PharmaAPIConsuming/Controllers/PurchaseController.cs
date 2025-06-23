using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmaAPIConsuming.DTO;
using System.Text;
using PharmaAPIConsuming.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace PharmaAPIConsuming.Controllers
{
    public class PurchaseController : Controller
    {
        HttpClient client = new HttpClient();

        private void LoadDropdowns()
        {
            // Load Suppliers
            var supplierResponse = client.GetAsync("https://localhost:7135/api/Supplier").Result;
            if (supplierResponse.IsSuccessStatusCode)
            {
                var json = supplierResponse.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Supplier>>(json);
                ViewBag.Suppliers = list.Select(s => new SelectListItem
                {
                    Value = s.SupplierId.ToString(),
                    Text = s.Name
                }).ToList();
            }

            // Load Branches
            var branchResponse = client.GetAsync("https://localhost:7135/api/Branch").Result;
            if (branchResponse.IsSuccessStatusCode)
            {
                var json = branchResponse.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Branch>>(json);
                ViewBag.Branches = list.Select(b => new SelectListItem
                {
                    Value = b.BranchId.ToString(),
                    Text = b.BranchName
                }).ToList();
            }
        }

        public IActionResult Index()
        {
            List<PurchaseReadDTO> data = new List<PurchaseReadDTO>();
            string url = "https://localhost:7135/api/Purchase";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<PurchaseReadDTO>>(json);
                if (obj != null)
                {
                    data = obj;
                }
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
        public IActionResult Add(PurchaseCreateDTO dto)
        {
            string url = "https://localhost:7135/api/Purchase";
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Suppliers = new SelectList( "SupplierId", "Name");
            ViewBag.Branches = new SelectList( "BranchId", "BranchName");


            LoadDropdowns();
            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoadDropdowns();
            ViewBag.PurchaseId = id;
          


            PurchaseUpdateDTO dto = new PurchaseUpdateDTO();
            string url = "https://localhost:7135/api/Purchase/"+id;

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<PurchaseReadDTO>(json);
                if (obj != null)
                {
                    dto.InvoiceNo = obj.InvoiceNo;
                    dto.PurchaseDate = obj.PurchaseDate;
                    dto.TotalAmount = obj.TotalAmount;
                    dto.SupplierId = 1; // Optional: Replace with actual values
                    dto.BranchId = 1;
                    dto.UpdatedBy = "admin";
                }
            }

            return View(dto);
        }


        [HttpPost]
        public IActionResult Edit(int id, PurchaseUpdateDTO dto)
        {
            string url = "https://localhost:7135/api/Purchase/" + id;
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            LoadDropdowns();
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            string url = "https://localhost:7135/api/Purchase/"+id;
            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return Content("<script>alert('Deleted successfully!'); window.location.href='/Purchase/Index';</script>", "text/html");
            }
            else
            {
                return Content("<script>alert('Delete failed!'); window.location.href='/Purchase/Index';</script>", "text/html");
            }
        }
    }
}
