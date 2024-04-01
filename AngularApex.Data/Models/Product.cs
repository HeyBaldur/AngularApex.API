using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Product()
        {
            OnCreated = DateTime.Now;
        }
    }
}
