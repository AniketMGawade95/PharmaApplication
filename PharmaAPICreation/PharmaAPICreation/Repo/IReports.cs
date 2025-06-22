using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
namespace PharmaAPICreation.Repo
{
    public interface IReports
    {
        int GetStockAlert();
        int ExpAlert();
        List<PurchaseItemDTO> GetStockAlert(PurchaseItemDTO dto);
        List<PurchaseItemDTO> ExpiryAlert();
        List<SaleItemsDTO> TotalSale();
        List<SaleItemsDTO> Top5();
        List<MonthlySalesDTO> GetMonthlySales();

    }
}
