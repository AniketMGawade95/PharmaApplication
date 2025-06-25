//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Microsoft.EntityFrameworkCore;

//using PharmaAPICreation.Data;
//using PharmaAPICreation.DTO;
//using PharmaAPICreation.Repo;

//namespace PharmaAPICreation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {

//        CustomerRepo repo;
//        ApplicationDbContext db;

//        public CustomerController(CustomerRepo repo, ApplicationDbContext db)
//        {
//             this.db=db;
//            this.repo = repo;
//        }

//        [HttpPost]
//        [Route("AddCustomer")]
//        public IActionResult AddCustomer(CustomerDTO dto)
//        {
//            repo.AddCustomer(dto);
//            return Ok("Added!!!");
//        }

//        [HttpGet]
//        [Route("AllCustomers")]
//        public IActionResult GetAllCustomers()
//        {
//            var data=repo.GetAllCustomers();
//            return Ok(data);
//        }

//        [HttpGet]
//        [Route("GetCustomer/{id}")]
//        public IActionResult SelectCustomer(int id)
//        {
//            var data = repo.SelectCustomer(id);
//            return Ok(data);
//        }

//        [HttpDelete]
//        [Route("DeleteCustomer/{id}")]
//        public IActionResult DeleteCustomer(int id)
//        {
//            repo.DeleteCustomer(id);
//            return Ok("Deleted!!!");
//        }

//        [HttpPut]
//        [Route("UpdateCustomer")]
//        public IActionResult UpdateCustomer(CustomerDTO dto)
//        {
//            repo.UpdateCustomer(dto);
//            return Ok("Updated!!!");

//        private readonly ICustomerRepository repo;
//        private readonly ApplicationDbContext db;
//        public CustomerController(ICustomerRepository repo, ApplicationDbContext db)
//        {
//            this.repo = repo;
//            this.db = db;   
//        }
//        //[HttpPost]
//        //[Route("AddCustomer")]
//        //public IActionResult AddCustomer(CustomerDTO customer)
//        //{
//        //    repo.AddCustomer(customer);
//        //    return Ok("Customer Added Successfully");
//        //}
//        [HttpGet]
//        [Route("GetAllCustomer")]
//        public IActionResult GetAllCustomer()
//        {
//            var data = repo.GetAll();
//            return Ok(data);
//        }
//        //[HttpPut]
//        //[Route("UpdateCustomr")]
//        //public IActionResult UpdateCustomer(CustomerDTO customer)
//        //{
//        //    repo.UpdateCustomer(customer);
//        //    return Ok("Customer Added successfully");
//        //}
//        //[HttpDelete]
//        //[Route("DeleteCustomerById{/id}")]
//        //public IActionResult DeleteCustomer(int id)
//        //{
//        //    repo.DeleteCustomer(id);
//        //    return Ok("Customer Deleted Successfully");


//        }
//        [HttpGet]
//        [Route("FetchSales")]
//        public IActionResult sales()
//        {

//            var data = db.Sales.Include(x => x.Customer).Include(x => x.SaleItems).ThenInclude(x => x.PurchaseItem).ThenInclude(x => x.Medicine).
//                SelectMany(x => x.SaleItems.Select(y => new PurchaseHistoryDTO()
//                {
//                    CustomerName = x.Customer.Name,
//                    Mobile = x.Customer.Mobile,
//                    MedicineName = y.PurchaseItem.Medicine.Name,

//            var data = db.Sales.Include(x => x.Customer).Include(x => x.SaleItems).ThenInclude(x => x.Medicine).
//                SelectMany(x => x.SaleItems.Select(y => new PurchaseHistoryDTO()
//                {
//                    CustomerName = x.CustomerName,
//                    Mobile = x.Customer.Mobile,
//                    MedicineName = y.Medicine.Name,

//                    TotalAmount = x.TotalAmount,
//                    Discount = y.Discount,
//                    Quantity = y.Quantity

//                })).ToList();
//            return Ok(data);
//        }

//    }
//}
