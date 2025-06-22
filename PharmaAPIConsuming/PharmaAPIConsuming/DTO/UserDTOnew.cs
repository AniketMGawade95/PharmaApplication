namespace PharmaAPIConsuming.DTO
{
    public class UserDTOnew
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }  
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
