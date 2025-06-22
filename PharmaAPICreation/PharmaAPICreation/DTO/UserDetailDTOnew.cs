namespace PharmaAPICreation.DTO
{
    public class UserDetailDTOnew
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
