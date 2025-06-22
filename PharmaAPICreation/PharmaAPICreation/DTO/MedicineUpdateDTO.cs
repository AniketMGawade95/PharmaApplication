using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.DTO
{
    public class MedicineUpdateDTO
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal GSTRate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
