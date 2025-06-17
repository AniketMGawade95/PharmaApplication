using System.ComponentModel.DataAnnotations;

namespace PharmaAPIConsuming.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
