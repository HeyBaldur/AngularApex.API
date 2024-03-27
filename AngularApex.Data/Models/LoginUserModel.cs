using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Data
{
    public class LoginUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
