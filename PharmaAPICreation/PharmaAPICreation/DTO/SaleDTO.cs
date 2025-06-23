namespace PharmaAPICreation.DTO
{
    public class SaleDTO
    {
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public string CreatedBy { get; set; }
        public List<SaleItemDTO> Items { get; set; }
    }
}
