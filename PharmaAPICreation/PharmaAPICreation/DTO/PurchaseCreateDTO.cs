using PharmaAPICreation.Models;
using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.DTO
{
    public class PurchaseCreateDTO
    {
        
            public int SupplierId { get; set; }
            public DateTime PurchaseDate { get; set; }
            public string InvoiceNo { get; set; }
            public decimal TotalAmount { get; set; }
            public int BranchId { get; set; }
            public string CreatedBy { get; set; }
        

    }



}
