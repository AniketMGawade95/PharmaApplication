using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.DTO
{
    public class BranchUpdateDTO
    {
        [Required]
        public string BranchName { get; set; }

        public string BranchAddress { get; set; }
    }
}
