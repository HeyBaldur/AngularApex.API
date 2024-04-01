using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public string AccountId { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string NoteText { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime OnCreated { get; set; }

        // Foreign key
        public virtual RegisterUserModel CreatedBy { get; set; }

        public Note()
        {
            OnCreated = DateTime.Now;
        }
    }
}
