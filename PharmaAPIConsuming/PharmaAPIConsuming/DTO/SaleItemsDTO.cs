namespace PharmaAPIConsuming.DTO
{
    public class SaleItemsDTO
    {
        public int Quantity { get; set; }
        public string MedicineName { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? SaleDate { get; set; }
    }
}
