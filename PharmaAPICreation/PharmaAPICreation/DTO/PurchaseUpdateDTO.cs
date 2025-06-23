namespace PharmaAPICreation.DTO
{
    public class PurchaseUpdateDTO
    {
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public int BranchId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
