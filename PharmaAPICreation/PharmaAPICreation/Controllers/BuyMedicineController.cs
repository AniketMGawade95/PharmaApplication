//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PharmaAPICreation.Data;
//using PharmaAPICreation.DTO;
//using PharmaAPICreation.Services;
//using PharmaAPICreation.Repo;
//using Razorpay.Api;

//namespace PharmaAPICreation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BuyMedicineController : ControllerBase
//    {
//        private readonly IBuyMedicineRepo _service;
//        private readonly ApplicationDbContext _context;

//        public BuyMedicineController(IBuyMedicineRepo service, ApplicationDbContext context)
//        {
//            _service = service;
//            _context = context;
//        }

//        /// <summary>
//        /// Get all available medicines.
//        /// </summary>
//        [HttpGet("medicines")]
//        public async Task<IActionResult> GetMedicines()
//        {
//            var medicines = await _service.GetAllMedicinesAsync();
//            return Ok(medicines);
//        }

//        /// <summary>
//        /// Get single medicine details by ID.
//        /// </summary>
//        [HttpGet("medicines/{id}")]
//        public async Task<IActionResult> GetMedicine(int id)
//        {
//            var medicine = await _service.GetMedicineByIdAsync(id);
//            if (medicine == null)
//                return NotFound();
//            return Ok(medicine);
//        }

//        /// <summary>
//        /// Create Razorpay order for medicine purchase.
//        /// </summary>
//        [HttpPost("create-order")]
//        public IActionResult CreateOrder([FromBody] RazorPayOrderDTO request)
//        //{
//            RazorpayClient client = new RazorpayClient("rzp_test_key", "secret_key");

//            var options = new Dictionary<string, object>
//            {
//                { "amount", request.Amount * 100 }, // in paise
//                { "currency", "INR" },
//                { "receipt", "receipt#1" },
//                { "payment_capture", 1 }
//            };

//            Order order = client.Order.Create(options);
//            return Ok(new { orderId = order["id"].ToString() });
//        }

//        /// <summary>
//        /// Get purchased medicines for user.
//        /// </summary>
//        [HttpGet("purchased/{userId}")]
