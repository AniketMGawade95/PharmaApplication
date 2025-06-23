namespace PharmaAPICreation.DTO
{
    public class PurchaseReadDTO
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string SupplierName { get; set; }
        public string BranchName { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
