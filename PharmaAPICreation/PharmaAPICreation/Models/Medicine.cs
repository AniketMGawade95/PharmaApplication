using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Medicine Name is required")]
        [StringLength(50,ErrorMessage ="Medicine name should be less than 50 characters")]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Category is required")]
        [StringLength(50,ErrorMessage = "Category should be less than 50 characters")]
        [Column(TypeName ="nvarchar(50)")]
        public string Category { get; set; }

        [Required(ErrorMessage ="Gst rate is required")]
        [Range(0,100,ErrorMessage ="GST Rate must be between 0 to 100")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal GSTRate { get; set; }
        public string? CreatedBy { get; set; } = null;

        [Column(TypeName = "datetime2")] 
        public DateTime? CreatedAt { get; set; } = null;
        public string? UpdatedBy { get; set; } = null;

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedAt { get; set; } = null;
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        //public ICollection<SaleItem> SaleItems { get; set; }
    }
}
