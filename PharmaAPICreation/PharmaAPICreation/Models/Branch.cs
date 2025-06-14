using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.Models
{
    public class Branch
    {


        [Key]
        public int BranchId { get; set; }

        [Required]
        public string BranchName { get; set; }

        public string BranchAddress { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Expense> Expenses { get; set; }

    }
}
