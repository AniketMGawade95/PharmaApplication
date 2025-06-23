using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface ICustomerRepository
    {
        void AddCustomer (CustomerDTO customers);
        void UpdateCustomer(CustomerDTO customers);
        void DeleteCustomer (int id);
        void Delete(List<int> ids);
        Customer GetCustomerById(int id);
        List<Customer> GetAll ();    
    }
}
