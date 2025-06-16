using PharmaAPICreation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.DTO
{
    public class AddUserDTO
    {

      
        public string Username { get; set; }
        
        public string PasswordHash { get; set; }
        
        public int RoleId { get; set; }          

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }       
        
        public int BranchId { get; set; } 

        
    }
}
