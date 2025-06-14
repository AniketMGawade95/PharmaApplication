using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public decimal GSTRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerUnit { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
