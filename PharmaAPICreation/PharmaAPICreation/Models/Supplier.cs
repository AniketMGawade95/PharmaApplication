using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
