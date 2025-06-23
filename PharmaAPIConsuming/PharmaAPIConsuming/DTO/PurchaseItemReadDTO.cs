namespace PharmaAPIConsuming.DTO
{
    public class PurchaseItemReadDTO
    {
        public int PurchaseItemId { get; set; }
        public int PurchaseId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
