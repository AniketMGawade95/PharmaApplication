using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface CustomerRepo
    {
        void AddCustomer(CustomerDTO dto);
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO SelectCustomer(int id);
        void UpdateCustomer(CustomerDTO dto);
        void DeleteCustomer(int id);

    }
}
