using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharmaAPIConsuming.DTO;
using PharmaAPIConsuming.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PharmaAPIConsuming.Controllers
{
    public class ReportsController : Controller
    {
        private readonly HttpClient _client;

        public ReportsController()
        {
            var handler = new HttpClientHandler
            {
                // Accept all certificates for dev environment
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7135") // Update to your API base URL
            };
        }

        // Main dashboard action
        public IActionResult Index()
        {
            var model = new DasbboardViewModel();

            try
            {
                // Stock Alert Count
                var stockAlertResp = _client.GetAsync("/api/reports/stock-alert-count").Result;
                if (stockAlertResp.IsSuccessStatusCode)
                    model.StockAlertCount = int.Parse(stockAlertResp.Content.ReadAsStringAsync().Result);

                // Expiry Alert Count
                var expiryAlertResp = _client.GetAsync("/api/reports/expiry-alert-count").Result;
                if (expiryAlertResp.IsSuccessStatusCode)
                    model.ExpiryAlertCount = int.Parse(expiryAlertResp.Content.ReadAsStringAsync().Result);

                // Today's Sales — note route changed to "Total-sales"
                var allSalesResp = _client.GetAsync("/api/reports/total-sales").Result;
                if (allSalesResp.IsSuccessStatusCode)
                {
                    var json = allSalesResp.Content.ReadAsStringAsync().Result;
                    model.AllSales = JsonConvert.DeserializeObject<List<SaleItemsDTO>>(json);
                }

                // Top 5 Medicines
                var top5Resp = _client.GetAsync("/api/reports/top5-medicines").Result;
                if (top5Resp.IsSuccessStatusCode)
                {
                    var json = top5Resp.Content.ReadAsStringAsync().Result;
                    model.Top5Medicines = JsonConvert.DeserializeObject<List<SaleItemsDTO>>(json);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "API call failed: " + ex.Message;
            }

            return View(model);
        }

        // AJAX endpoint to fetch monthly sales data for chart
        [HttpGet]
        public IActionResult GetMonthlySalesData()
        {
            List<MonthlySalesDTO> result = new List<MonthlySalesDTO>();

            try
            {
                var response = _client.GetAsync("/api/reports/monthly-sales").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<MonthlySalesDTO>>(json);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("API error: " + ex.Message);
            }

            return Json(result);
        }

        // View to display monthly sales chart (calls GetMonthlySalesData via AJAX)
        public IActionResult MonthlySalesChart()
        {
            return View();
        }
    }
}
