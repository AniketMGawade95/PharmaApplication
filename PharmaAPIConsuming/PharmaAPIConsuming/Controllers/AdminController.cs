using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;
using PharmaAPIConsuming.Data;
using PharmaAPIConsuming.DTO;
using Razorpay.Api;
using System.Text;

namespace PharmaAPIConsuming.Controllers
{
    public class AdminController : Controller
    {


        HttpClient client;


        public AdminController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);




        }

        private readonly string baseUrl = "https://localhost:7135/api/Admin/";


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }




        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddRole(AddRolesDTO dd)
        {
            string url = "https://localhost:7135/api/Admin/AddRoles";
            var json = JsonConvert.SerializeObject(dd);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Role added successfully!";
                return RedirectToAction("AddRole");
            }


            ModelState.AddModelError("", "Failed to add role.");
            return View(dd);

        }

        [HttpGet]
        public IActionResult viewRoles()
        {
            List<ViewRolesDTO> data = new List<ViewRolesDTO>();
            string url = "https://localhost:7135/api/Admin/FetchingRoles";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<ViewRolesDTO>>(json);
                if (obj != null)
                {
                    data = obj;
                }
            }

            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> FetchRoles()
        {
            string url = "https://localhost:7135/api/Admin/FetchingRoles";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var roles = JsonConvert.DeserializeObject<List<ViewRolesDTO>>(json);
                return Json(roles);
            }

            return Json(new List<ViewRolesDTO>());
        }



        [HttpPost]
        public IActionResult DeleteRole(int id)
        {
            string url = $"https://localhost:7135/api/Admin/DeleteRole/{id}";

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Role deleted successfully!";
            }
            else
            {
                TempData["error"] = "Failed to delete role!";
            }

            return RedirectToAction("ViewRoles");
        }


        public IActionResult GetRole(int id)
        {
            RoleGetID data = new RoleGetID();
            string url = $"https://localhost:7135/api/Admin/GetRole/{id}";

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<RoleGetID>(json);
                if (obj != null)
                {
                    data = obj;
                }
            }

            return View(data);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleGetID dto)
        {
            var updateDto = new
            {
                RoleName = dto.RoleName
            };

            var json = JsonConvert.SerializeObject(updateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://localhost:7135/api/Admin/UpdateRole/{dto.RoleId}";
            var response = await new HttpClient().PutAsync(url, content);

            //return Json(response.IsSuccessStatusCode);
            return RedirectToAction("viewRoles");
        }






        [HttpGet]
        public IActionResult ManageBranches()
        {
            return View();
        }





        [HttpGet]
        public async Task<IActionResult> FetchBranches()
        {
            var response = await client.GetAsync($"{baseUrl}FetchBranches");
            var json = await response.Content.ReadAsStringAsync();
            var branches = JsonConvert.DeserializeObject<List<BranchDTO>>(json);
            return Json(branches);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}AddBranches", content);
            return Json(response.IsSuccessStatusCode);
        }


        [HttpGet]
        public async Task<IActionResult> GetBranchById(int branchId)
        {
            var response = await client.GetAsync($"{baseUrl}GetBranch/{branchId}");
            var json = await response.Content.ReadAsStringAsync();
            var branch = JsonConvert.DeserializeObject<BranchDTO>(json);
            return Json(branch);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateBranch(BranchDTO dto)
        {
            var json = JsonConvert.SerializeObject(new { dto.BranchName, dto.BranchAddress });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}UpdateBranch/{dto.BranchId}", content);
            return Json(response.IsSuccessStatusCode);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            var response = await client.DeleteAsync($"{baseUrl}DeleteBranch/{branchId}");
            return Json(response.IsSuccessStatusCode);
        }








        public IActionResult ManageSuppliers()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FetchSuppliers()
        {
            var response = await client.GetAsync(baseUrl + "FetchSupplier");
            var json = await response.Content.ReadAsStringAsync();
            var suppliers = JsonConvert.DeserializeObject<List<SupplierDTO>>(json);
            return Json(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierDTO dto)
        {
            dto.CreatedBy = "Admin";
            dto.UpdatedBy = "Admin";
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(baseUrl + "AddSupplier", content);
            return Json(response.IsSuccessStatusCode);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(SupplierDTO dto)
        {
            dto.UpdatedBy = "Admin";
            var updateDto = new
            {
                dto.Name,
                dto.Contact,
                dto.Address,
                dto.UpdatedBy
            };

            var json = JsonConvert.SerializeObject(updateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(baseUrl + $"UpdateSupplier/{dto.SupplierId}", content);
            return Json(response.IsSuccessStatusCode);
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var response = await client.GetAsync(baseUrl + $"GetSupplier/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var supplier = JsonConvert.DeserializeObject<SupplierDTO>(json);
            return Json(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var response = await client.DeleteAsync(baseUrl + $"DeleteSuppliers/{id}");
            return Json(response.IsSuccessStatusCode);
        }










        [HttpPost]
        public IActionResult EditEmp(RoleGetID dto)
        {
            string url = "https://localhost:7135/api/Admin/UpdateRole/" + dto.RoleId;


            var updateDto = new
            {
                RoleName = dto.RoleName
            };

            var json = JsonConvert.SerializeObject(updateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Role updated successfully!";
                return RedirectToAction("viewRoles");
            }
            else
            {
                TempData["error"] = "Failed to update Role!";
                return View(dto);
            }
        }






        public IActionResult ManageUsers()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FetchUsers()
        {
            var response = await client.GetAsync($"{baseUrl}FetchUsers");
            var json = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDetailDTO>>(json);
            return Json(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDTO dto)
        {
            dto.CreatedBy = "Admin";
            dto.UpdatedBy = "Admin";
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}AddUser", content);
            return Json(response.IsSuccessStatusCode);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUsers(UserDetailDTO dto)
        {
            var json = JsonConvert.SerializeObject(new
            {
                dto.UserId,
                dto.Username,
                dto.UserEmail,
                dto.PasswordHash,
                dto.RoleId,
                dto.BranchId,
                dto.UpdatedBy
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PutAsync($"{baseUrl}UpdateUser/{dto.UserId}", content);

            return Json(response.IsSuccessStatusCode);
        }






        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await client.GetAsync($"{baseUrl}GetUser/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDetailDTO>(json);
            return Json(user);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await client.DeleteAsync($"{baseUrl}DeleteUser/{id}");
            return Json(response.IsSuccessStatusCode);
        }



        //public IActionResult ManageUsersnew()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> AddUser(UserDTOnew dto)
        //{
        //    dto.CreatedBy = HttpContext.Session.GetString("Username"); // or "Admin"
        //    var json = JsonConvert.SerializeObject(dto);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync($"{baseUrl}AddUser", content);
        //    return Json(response.IsSuccessStatusCode);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateUser(UserDTOnew dto)
        //{
        //    dto.UpdatedBy = HttpContext.Session.GetString("Username"); // or "Admin"
        //    var json = JsonConvert.SerializeObject(dto);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync($"{baseUrl}UpdateUser", content);
        //    return Json(response.IsSuccessStatusCode);
        //}




        //[HttpGet]
        //public async Task<IActionResult> FetchUsers()
        //{
        //    var response = await client.GetAsync($"{baseUrl}FetchUsers");
        //    var json = await response.Content.ReadAsStringAsync();
        //    var data = JsonConvert.DeserializeObject<List<UserDTOnew>>(json);
        //    return Json(data);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUserById(int userId)
        //{
        //    var response = await client.GetAsync($"{baseUrl}GetUser?id={userId}");
        //    var json = await response.Content.ReadAsStringAsync();
        //    var user = JsonConvert.DeserializeObject<UserDTOnew>(json);
        //    return Json(user);
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeleteUser(int userId)
        //{
        //    var response = await client.DeleteAsync($"{baseUrl}DeleteUser?id={userId}");
        //    return Json(response.IsSuccessStatusCode);
        //}







        [Route("Admin/CreateOrder")]
        [HttpPost]
        public IActionResult CreateOrder([FromForm] double amount)
        {
            try
            {
                string keyId = "rzp_test_Kl7588Yie2yJTV";
                string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

                RazorpayClient client = new RazorpayClient(keyId, keySecret);

                var options = new Dictionary<string, object>
        {
            { "amount", (int)(amount * 100) },
            { "currency", "INR" },
            { "receipt", "rcpt_" + Guid.NewGuid().ToString("N").Substring(0, 32) },
            { "payment_capture", 1 }
        };

                var order = client.Order.Create(options);
                return Json(order["id"].ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("Razorpay error: " + ex.Message);
            }
        }



    }


 }

