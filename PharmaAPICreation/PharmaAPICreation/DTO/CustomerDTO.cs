

﻿using System.ComponentModel.DataAnnotations;

namespace PharmaAPICreation.DTO
{
    public class CustomerDTO
    {
     

        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public string EmailId { get; set; }

        //public string CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
