using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;
using System.Reflection;

namespace PharmaAPICreation.Services
{
    public class CustomerServices : CustomerRepo
    {
        ApplicationDbContext db;
        IMapper mapper;

        public CustomerServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddCustomer(CustomerDTO dto)
        {
            var c = mapper.Map<Customer>(dto);
            //c.CreatedAt = DateTime.UtcNow;
            //c.CreatedBy = dto.CreatedBy;
            db.Customers.Add(c);
            db.SaveChanges();
        }


        
        public CustomerDTO SelectCustomer(int id)
        {
            var c = db.Customers.Find(id);
            var data = mapper.Map<CustomerDTO>(c);
            return data;
            
        }

        public void DeleteCustomer(int id)
        {
            var c = db.Customers.Find(id);
            db.Customers.Remove(c);
            db.SaveChanges();
        }


        public void UpdateCustomer(CustomerDTO dto)
        {
            var c = mapper.Map<Customer>(dto);
            //c.UpdatedBy = dto.UpdatedBy;
            //c.UpdatedAt = DateTime.UtcNow;
            db.Customers.Update(c);
            db.SaveChanges();
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            var c = db.Customers.ToList();
            var data = mapper.Map<List<CustomerDTO>>(c);
            return data;
        }
    }
}
