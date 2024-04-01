using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CloseDate { get; set; }
        public string Stage { get; set; }
        public decimal Probability { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign key
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Opportunity()
        {
            OnCreated = DateTime.Now;
        }
    }
}
