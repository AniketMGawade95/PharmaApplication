
using PharmaAPICreation.Data;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Models;
using PharmaAPICreation.DTO;
using Microsoft.EntityFrameworkCore;
namespace PharmaAPICreation.Services
{
    public class ReportsServices : IReports
    {
        ApplicationDbContext db;
        public ReportsServices(ApplicationDbContext db)
        {
            this.db = db;
        }


        public int GetStockAlert()
        {
            int lowstockCount = db.PurchaseItems.Where(x => x.Quantity < 30).Count();
            return lowstockCount;
        }

        public int ExpAlert()
        {
            DateTime days = DateTime.Now + TimeSpan.FromDays(30);
            int expiryalert = db.PurchaseItems
           .Where(x => x.ExpiryDate <= days)
           .Count();

            return expiryalert;
        }

        public List<PurchaseItemDTO> GetStockAlert(PurchaseItemDTO dto)
        {
            var stockAlert = db.PurchaseItems
               .Include(x => x.Medicine)
               .Where(x => x.ExpiryDate <= DateTime.Now)
               .Select(x => new PurchaseItemDTO
               {
                   PurchaseItemId = x.PurchaseItemId,
                   PurchaseId = x.PurchaseId,
                   MedicineId = x.MedicineId,
                   Name = x.Medicine.Name,
                   BatchNumber = x.BatchNumber,
                   Quantity = x.Quantity,
                   Price = x.Price,
                   ExpiryDate = x.ExpiryDate,
                   ManufactureDate = x.ManufactureDate,
                   Manufacturer = x.Manufacturer
               })
               .ToList();

            return stockAlert;
        }

        public List<PurchaseItemDTO> ExpiryAlert()
        {
            var stockAlert = db.PurchaseItems.Where(x => x.ExpiryDate <= DateTime.Now).Include(x => x.Medicine).Select(x => new PurchaseItemDTO
            {
                PurchaseItemId = x.PurchaseItemId,
                PurchaseId = x.PurchaseId,
                MedicineId = x.MedicineId,
                Name = x.Medicine.Name,
                BatchNumber = x.BatchNumber,
                Quantity = x.Quantity,
                Price = x.Price,
                ExpiryDate = x.ExpiryDate,
                ManufactureDate = x.ManufactureDate,
                Manufacturer = x.Manufacturer
            }).ToList();
            return stockAlert;
        }


        public List<SaleItemsDTO> TotalSale()
        {
            var totalSale = db.SaleItems
           .Include(x => x.Sale)
           .Include(x => x.PurchaseItem)
           .ThenInclude(p => p.Medicine)
           .Where(x => x.Sale.SaleDate.Date == DateTime.Today.Date)
           .Select(x => new SaleItemsDTO
           {
               SaleDate = x.Sale.SaleDate,
               Quantity = x.Quantity,
               Discount = x.Discount,
               TotalPrice = x.TotalPrice,
               MedicineName = x.PurchaseItem.Medicine != null ? x.PurchaseItem.Medicine.Name : null
           })
           .ToList();

            return totalSale;
        }

        public List<SaleItemsDTO> Top5()
        {

            var top5 = db.SaleItems.Include(x => x.PurchaseItem).ThenInclude(p => p.Medicine) 
                      .GroupBy(x => x.PurchaseItem.Medicine.Name)
                        .Select(g => new SaleItemsDTO
                        {
                            Quantity = g.Sum(x => x.Quantity),
                            MedicineName = g.Key
                        })
                        .OrderByDescending(x => x.Quantity)
                        .Take(5)
                        .ToList();

                         return top5;
        }
        public List<MonthlySalesDTO> GetMonthlySales()
        {
            var monthlySales = db.SaleItems
                .Include(x => x.Sale)
                .Where(x => x.Sale.SaleDate.Year == DateTime.Now.Year)
                .GroupBy(x => x.Sale.SaleDate.Month)
                .Select(g => new MonthlySalesDTO
                {
                    Month = new DateTime(DateTime.Now.Year, g.Key, 1).ToString("MMM"),
                    TotalSales = g.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => DateTime.ParseExact(x.Month, "MMM", null).Month)
                .ToList();

            return monthlySales;
        }

    }

}
