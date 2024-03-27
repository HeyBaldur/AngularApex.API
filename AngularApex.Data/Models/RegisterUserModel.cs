using System;
using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class RegisterUserModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public RegisterUserModel()
        {
            CreatedOn = DateTime.UtcNow;
        }
    }
}
