using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string AccountId { get; set; }
        public int CustomerId { get; set; }
        public int CreatedById { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Foreign key
        public virtual Customer Customer { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Contact()
        {
            OnCreated = DateTime.Now;
        }
    }
}
