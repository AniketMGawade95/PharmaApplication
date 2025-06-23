using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Services;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReports _reports;

        public ReportsController(IReports reports)
        {
            _reports = reports;
        }

        // GET: api/reports/stock-alert-count
        [HttpGet]
        [Route(("stock-alert-count"))]
        public IActionResult GetStockAlertCount()
        {
            var count = _reports.GetStockAlert();
            return Ok(count);
        }

        // GET: api/reports/expiry-alert-count
        [HttpGet]
        [Route(("expiry-alert-count"))]
        public IActionResult GetExpiryAlertCount()
        {
            var count = _reports.ExpAlert();
            return Ok(count);
        }

        // GET: api/reports/expired-stock
        [HttpGet]
        [Route(("expired-stock"))]
        public IActionResult GetExpiredStock()
        {
            var result = _reports.ExpiryAlert();
            return Ok(result);
        }

        // GET: api/reports/today-sales
        [HttpGet]
        [Route(("today-sales"))]
        public IActionResult GetTodaySales()
        {
            var result = _reports.TotalSale();
            return Ok(result);
        }

        // GET: api/reports/top5-medicines
        [HttpGet]
        [Route(("top5-medicines"))]
        public IActionResult GetTop5Medicines()
        {
            var result = _reports.Top5();
            return Ok(result);
        }

        // POST: api/reports/expired-stock-by-dto
        [HttpPost]
        [Route(("expired-stock-by-dto"))]
        public IActionResult GetExpiredStockByDTO([FromBody] PurchaseItemDTO dto)
        {
            var result = _reports.GetStockAlert(dto);
            return Ok(result);
        }
        [Route("monthly-sales")]
        [HttpGet]
        public IActionResult GetMonthlySales()
        {
            var data = _reports.GetMonthlySales();
            return Ok(data);
        }

        [Route("Total-sales")]
        [HttpGet]
        public IActionResult TotalSale()
        {
            var data = _reports.TotalSale();
            return Ok(data);
        }
    }
}
