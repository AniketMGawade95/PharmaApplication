using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface IPurchaseItemRepo
    {
        IEnumerable<PurchaseItem> GetAll();
        PurchaseItem GetById(int id);
        void Add(PurchaseItem item);
        void Update(PurchaseItem item);
        void Delete(int id);
    }
}
