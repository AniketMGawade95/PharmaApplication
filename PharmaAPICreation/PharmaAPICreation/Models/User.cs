using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }  // New FK

        public Role Role { get; set; }   // Navigation property

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }  // Existing FK to branch

        public Branch Branch { get; set; }


        public ICollection<AuditLog> AuditLogs { get; set; }
    }
}
