using System.ComponentModel.DataAnnotations;

namespace PharmaAPIConsuming.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string BranchName { get; set; }

        public string BranchAddress { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
