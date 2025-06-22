namespace PharmaAPICreation.DTO
{
    public class SaleItemsDTO
    {
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        public int PurchaseItemId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Optional: include nested info (like SaleDate or MedicineName) if needed
        public DateTime? SaleDate { get; set; } // from Sale
        public string MedicineName { get; set; }
    }
}
