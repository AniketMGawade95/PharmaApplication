using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
<<<<<<< Updated upstream

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
=======
        public string EmailId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
>>>>>>> Stashed changes
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Sale>? Sales { get; set; }
    }
}
