using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class SaleItem
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Sale")]
        public int SaleId { get; set; }

        public Sale Sale { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
