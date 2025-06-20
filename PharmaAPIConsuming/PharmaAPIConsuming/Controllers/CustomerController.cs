using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmaAPIConsuming.DTO;
using System.Text;

namespace PharmaAPIConsuming.Controllers
{
    public class CustomerController : Controller
    {
        HttpClient client;

        public CustomerController()
        {
            HttpClientHandler cl = new HttpClientHandler();
            cl.ServerCertificateCustomValidationCallback =
                (Sender, cert, chain, SslPolicyErrors) => { return true; };

            client = new HttpClient(cl);
        }
        public IActionResult Index()
        {
            List<CustomerDTO> data = new List<CustomerDTO>();
            string url = "https://localhost:7135/api/Customer/AllCustomers/";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<CustomerDTO>>(jsondata);

                if (obj != null)
                {
                    data = obj;
                }
            }
            return View(data);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDTO c)
        {
            //string? username = HttpContext.Session.GetString("Login");

            //customer.CreatedBy = username;
            //customer.CreatedAt = DateTime.UtcNow;
            string url = "https://localhost:7135/api/Customer/AddCustomer/";

            var json = JsonConvert.SerializeObject(c);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult GetCustomer(int id)
        {
            CustomerDTO data = new CustomerDTO();
            string url = "https://localhost:7135/api/Customer/GetCustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<CustomerDTO>(jsondata);

                if (obj != null)
                {
                    data = obj;
                }

            }
            return View(data);
        }

        public IActionResult EditCustomer(int id)
        {
            CustomerDTO data = new CustomerDTO();
            string url = "https://localhost:7135/api/Customer/GetCustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<CustomerDTO>(jsondata);

                if (obj != null)
                {
                    data = obj;
                }

            }
            return View(data);
        }

        [HttpPost]
        public IActionResult EditCustomer(CustomerDTO c) 
        {
            //string? username = HttpContext.Session.GetString("Login");

            //customer.UpdatedBy = username;
            //customer.UpdatedAt = DateTime.UtcNow;
            string url = "https://localhost:7135/api/Customer/UpdateCustomer";
            var json = JsonConvert.SerializeObject(c);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int id) 
        {
            string url = $"https://localhost:7135/api/Customer/DeleteCustomer/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Failed to delete customer.";
                return View("Error");
            }
        }
    }
}
