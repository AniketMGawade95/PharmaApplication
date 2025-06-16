using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PharmaAPIConsuming.DTO;
using System.Reflection;
using System.Text;

namespace PharmaAPIConsuming.Controllers
{
    public class AuthController : Controller
    {

        HttpClient client;
        public AuthController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO dto)
        //{
            //string url = "https://localhost:7030/api/Login";
            //var json = JsonConvert.SerializeObject(dto);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync(url, content);

            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadFromJsonAsync<LoginResponseDTOClass>();

            //    HttpContext.Session.SetInt32("UserID", result.UserId);
            //    HttpContext.Session.SetString("Username", result.Username);
            //    HttpContext.Session.SetString("Role", result.RoleName);

            //    if (result.RoleName == "Admin")
            //        return RedirectToAction("Index", "AdminDashboard");
            //    else if (result.RoleName == "Pharmacist")
            //        return RedirectToAction("Index", "PharmacistDashboard");
            //    else
            //        return RedirectToAction("Index", "CashierDashboard");
            //}

            //ViewBag.Error = "Invalid login credentials";
            //return View();
        //}


        public IActionResult Register()
        {
            List<BranchDTO> data = new List<BranchDTO>();
            string url = "https://localhost:7135/api/Auth/FetchBranch";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<BranchDTO>>(json);
                if (obj != null)
                {
                    data = obj;
                }
            }
            ViewBag.branch = new SelectList(data, "BranchId", "BranchName");
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterDTO em)
        {
            string url = "https://localhost:7135/api/Auth/AddUser";
            var json = JsonConvert.SerializeObject(em);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            return View();

        }


    }
}
