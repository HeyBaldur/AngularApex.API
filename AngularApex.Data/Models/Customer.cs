using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Customer
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
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Customer()
        {
            OnCreated = DateTime.Now;
        }
    }
}
