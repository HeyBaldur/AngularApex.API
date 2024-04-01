using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid Identificator { get; set; }
        public int CreatedById { get; set; }
        public virtual RegisterUserModel CreatedBy { get; set; }
    }
}
