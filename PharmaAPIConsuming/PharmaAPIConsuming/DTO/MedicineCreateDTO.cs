namespace PharmaAPIConsuming.DTO
{
    public class MedicineCreateDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal GSTRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
