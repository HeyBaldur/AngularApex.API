using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Data
{
    /// <summary>
    /// User roles.
    /// </summary>
    public class UserRolesModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NormalizedName { get; set; }
    }
}
