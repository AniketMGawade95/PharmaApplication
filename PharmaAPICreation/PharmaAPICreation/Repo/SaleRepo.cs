using PharmaAPICreation.DTO;

namespace PharmaAPICreation.Repo
{
    public interface SaleRepo
    {
        void AddSale(SaleDTO dto);
        SaleDTO GetSale(int id);
    }
}
