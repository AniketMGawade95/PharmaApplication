using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class PurchaseItem
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public string BatchNo { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
