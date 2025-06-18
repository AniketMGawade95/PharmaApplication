using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PharmaAPIConsuming.Data;
using PharmaAPIConsuming.DTO;
using PharmaAPIConsuming.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace PharmaAPIConsuming.Controllers
{
    public class AuthController : Controller
    {

        HttpClient client;
        AppDbCcontext db;
        public AuthController(AppDbCcontext db)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);

            this.db = db;
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



        [HttpPost]
        public IActionResult Login(User u)
        {
            //var data = db.Users.Incude(Role).Where(x => x.Username.Equals(u.Username)).SingleOrDefault();
            var data = db.Users.Include(x => x.Role).FirstOrDefault(x => x.Username == u.Username);

            if (data != null)
            {
                var pass = BCrypt.Net.BCrypt.Verify(u.PasswordHash, data.PasswordHash);
                if (pass)
                {

                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,data.Username),
                        new Claim(ClaimTypes.Role,data.Role.RoleName)
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Username", data.Username);

                    if (data.Role.RoleName == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    if (data.Role.RoleName == "Pharmacist")
                    {
                        return RedirectToAction("Index", "Pharma");
                    }
                    if (data.Role.RoleName == "Cashier")
                    {
                        return RedirectToAction("Dashboard", "Cashier");
                    }
                    if (data.Role.RoleName == "User")
                    {
                        return RedirectToAction("Dashboard", "User");
                    }
                    else
                    {
                        TempData["RoleError"] = "Unknown Role";
                        return View();
                    }



                }
                else
                {
                    TempData["InPass"] = "Invalid Password";
                    return View();
                }

            }
            else
            {
                TempData["InUsername"] = "Invalid Username";
                return View();
            }


        }












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










        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var allcookies = Request.Cookies.Keys;

            HttpContext.Session.Clear();

            foreach (var cookie in allcookies)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("Login", "Auth");
        }


    }
}
