using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string AccountId { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation properties
        public virtual RegisterUserModel CreatedBy { get; set; }
    }
}
