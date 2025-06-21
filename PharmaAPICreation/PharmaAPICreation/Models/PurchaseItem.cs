using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class PurchaseItem
    {
        [Key]
        public int PurchaseItemId { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }

        public string? BatchNumber { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }

        public string? Manufacturer { get; set; }

        public string? CreatedBy { get; set; } = null;
        public DateTime? CreatedAt { get; set; } = null;
        public string? UpdatedBy { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;

        public ICollection<SaleItem>? SaleItems { get; set; }
    }
}
