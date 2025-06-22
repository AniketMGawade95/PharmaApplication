using PharmaAPIConsuming.DTO;

namespace PharmaAPIConsuming.Models
{
    public class DashboardViewModel
    {
        public int StockAlertCount { get; set; }
        public int ExpiryAlertCount { get; set; }
        public List<SaleItemsDTO> TodaySales { get; set; }
        public List<SaleItemsDTO> Top5Medicines { get; set; }
        public List<SaleItemsDTO>? AllSales { get; internal set; }
    }
}
