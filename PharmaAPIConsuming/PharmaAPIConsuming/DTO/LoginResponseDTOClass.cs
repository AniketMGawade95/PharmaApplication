﻿namespace PharmaAPIConsuming.DTO
{
    public class LoginResponseDTOClass
    {
        public class LoginResponseDTO
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string RoleName { get; set; }
            public int BranchId { get; set; }
        }

    }
}
