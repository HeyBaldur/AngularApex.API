using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int OpportunityId { get; set; }
        public int AssignedToId { get; set; }
        public int AssignedToUserId { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public string AccountId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime OnCreated { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }

        // Foreign keys
        public virtual Opportunity Opportunity { get; set; }
        public virtual RegisterUserModel AssignedTo { get; set; }
        public virtual RegisterUserModel AssignedToUser { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Activity()
        {
            OnCreated = DateTime.Now;
        }
    }
}
