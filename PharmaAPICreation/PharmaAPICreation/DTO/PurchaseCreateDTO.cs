namespace PharmaAPICreation.DTO
{
    public class PurchaseCreateDTO
    {
        public int SupplierId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PurchaseDate { get; set; }

        public List<PurchaseItemCreateDTO> PurchaseItems { get; set; }
    }
}
