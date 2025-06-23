namespace PharmaAPIConsuming.DTO
{
    public class PurchaseItemCreateDTO
    {
        public int PurchaseId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int BranchId { get; set; }
        public string CreatedBy { get; set; }
    }
}
