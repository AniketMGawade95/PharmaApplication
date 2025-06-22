using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.DTO
{
    public class UpdateRoleDTO
    {
        [Required]
        public string RoleName { get; set; }
    }
}
