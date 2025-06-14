using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaAPICreation.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }

        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string Operation { get; set; } // Create, Update, Delete
        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
