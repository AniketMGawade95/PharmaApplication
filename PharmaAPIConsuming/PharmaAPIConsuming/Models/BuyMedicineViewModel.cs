namespace PharmaAPIConsuming.Models
{
    public class BuyMedicineViewModel
    {
        public int PurchaseItemId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string CreatedBy { get; set; } = "";

        // payment fields
        public string PaymentMethod { get; set; } = "UPI";
        public string PaymentStatus { get; set; } = "Success";
        public string TransactionId { get; set; } = "";

        // API response
        public string? Message { get; set; }
    }
}
