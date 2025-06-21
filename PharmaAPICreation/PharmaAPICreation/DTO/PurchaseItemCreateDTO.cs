using PharmaAPICreation.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.DTO
{
    public class PurchaseItemCreateDTO

    {
        public int PurchaseId { get; set; }      
        public int MedicineId { get; set; }       

        public string BatchNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }

        public string Manufacturer { get; set; }
        public string CreatedBy { get; set; }
    }


}
