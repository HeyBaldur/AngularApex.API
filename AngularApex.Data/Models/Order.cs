using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Required]
        public string AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedById { get; set; }

        // Navigation property
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Order()
        {
            OnCreated = DateTime.Now;
        }
    }
}
