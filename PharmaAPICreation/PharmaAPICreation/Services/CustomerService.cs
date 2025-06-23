using PharmaAPICreation.Data;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Models;
using PharmaAPICreation.DTO;

namespace PharmaAPICreation.Services
{
    public class CustomerService : ICustomerRepository
    {
        ApplicationDbContext db;
        public CustomerService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var data = new Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                EmailId = customer.EmailId,
                Mobile= customer.Mobile,
                CreatedAt = DateTime.Now,
                CreatedBy ="Cashier",
                UpdatedAt = DateTime.Now,
                UpdatedBy ="Cashier"

            };
            db.Customers.Add(data);
            db.SaveChanges();
        }

        public List<Customer> GetAll()
        { 
           var data = db.Customers.ToList();
            return( data);
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            var data = new Customer()
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                EmailId = customer.EmailId,
                Mobile = customer.Mobile,
                CreatedAt = DateTime.Now,
                CreatedBy = "Cashier",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Cashier"

            };
            db.Customers.Update(data);
            db.SaveChanges();

        }
        public void DeleteCustomer(int id)
        {
            var data = db.Customers.Find(id);
            db.Customers.Remove(data);
            db.SaveChanges();
        }
        public void Delete(List<int> ids)
        {
            foreach(var id in ids)
            {
                var data = db.Customers.Find(id);
                if(data != null)
                {
                    db.Customers.RemoveRange(data);
                   
                }
            }
            db.SaveChanges();
        }
        public Customer GetCustomerById(int id)
        {
            return db.Customers.Find(id);

        }
    }
}
