using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface IPurchaseRepo
    {
        IEnumerable<Purchase> GetAll();
        Purchase GetById(int id);
        void Add(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int id);

    }
}
