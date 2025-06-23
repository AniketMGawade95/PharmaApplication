using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;
using Microsoft.EntityFrameworkCore;

namespace PharmaAPICreation.Services
{
    public class SaleService : SaleRepo
    {
        private readonly ApplicationDbContext db;

        public SaleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddSale(SaleDTO dto)
        {
            var sale = new Sale
            {
                CustomerId = dto.CustomerId,
                BranchId = dto.BranchId,
                SaleDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                SaleItems = new List<SaleItem>()
            };

            decimal total = 0;

            foreach (var itemDto in dto.Items)
            {
                var purchaseItem = db.PurchaseItems
                                      .Include(p => p.Medicine)
                                      .FirstOrDefault(p => p.PurchaseItemId == itemDto.PurchaseItemId);

                if (purchaseItem == null || purchaseItem.Medicine == null)
                {
                    throw new Exception("Invalid PurchaseItemId or related Medicine not found: " + itemDto.PurchaseItemId);
                }

                var unitPrice = purchaseItem.Price;
                var qty = itemDto.Quantity;
                var gstRate = purchaseItem.Medicine.GSTRate;

                var discountAmount = (unitPrice * qty) * (itemDto.Discount / 100);
                var priceAfterDiscount = (unitPrice * qty) - discountAmount;
                var tax = priceAfterDiscount * (gstRate / 100);
                var totalPrice = priceAfterDiscount + tax;

                // Reduce stock
                if (purchaseItem.Quantity < qty)
                    throw new Exception($"Not enough stock for PurchaseItemId {itemDto.PurchaseItemId}");
                purchaseItem.Quantity -= qty;

                var saleItem = new SaleItem
                {
                    PurchaseItemId = itemDto.PurchaseItemId,
                    Quantity = qty,
                    UnitPrice = unitPrice,
                    Discount = discountAmount,
                    Tax = tax,
                    TotalPrice = totalPrice,
                    CreatedAt = DateTime.Now,
                    CreatedBy = dto.CreatedBy
                };

                sale.SaleItems.Add(saleItem);
                total += totalPrice;
            }

            sale.TotalAmount = total;
            db.Sales.Add(sale);
            db.SaveChanges();
        }

        public SaleDTO GetSale(int id)
        {
            var sale = db.Sales
                         .Include(s => s.SaleItems)
                         .ThenInclude(si => si.PurchaseItem)
                         .ThenInclude(pi => pi.Medicine)
                         .FirstOrDefault(s => s.SaleId == id);

            if (sale == null) return null;

            return new SaleDTO
            {
                CustomerId = sale.CustomerId,
                BranchId = sale.BranchId,
                CreatedBy = sale.CreatedBy,
                Items = sale.SaleItems.Select(si => new SaleItemDTO
                {
                    PurchaseItemId = si.PurchaseItemId,
                    Quantity = si.Quantity,
                    Discount = (si.UnitPrice * si.Quantity) == 0 ? 0 : (si.Discount * 100) / (si.UnitPrice * si.Quantity)
                }).ToList()
            };
        }
    }
}
