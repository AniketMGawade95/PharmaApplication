namespace PharmaAPICreation.DTO
{
    public class PurchaseItemDTO
    {
        public int PurchaseItemId { get; set; }
        public int PurchaseId { get; set; }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }

        public string BatchNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }

        public string Manufacturer { get; set; }
    }
}
