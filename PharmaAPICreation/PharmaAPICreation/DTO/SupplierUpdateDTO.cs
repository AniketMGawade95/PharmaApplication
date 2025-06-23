using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.DTO
{
    public class SupplierUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }

        public string UpdatedBy { get; set; }
    }
}
