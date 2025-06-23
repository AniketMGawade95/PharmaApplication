using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmaAPIConsuming.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YourMvcApp.Controllers
{
    public class BuyMedicineController : Controller
    {
        // TODO: replace with your real API base URL
        private const string ApiUrl = "https://localhost:7135/api/BuyMedicine/BuyMedicine";

        [HttpGet]
        public IActionResult BuyMedicine()
        {
            return View(new BuyMedicineViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> BuyMedicine(BuyMedicineViewModel model)
        {
            // serialize the ViewModel to JSON
            var payload = JsonConvert.SerializeObject(model);
            using var client = new HttpClient();
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            // call API
            var response = await client.PostAsync(ApiUrl, content);
            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);

            model.Message = result?.message ?? "No response";
            return View(model);
        }
    }
}
