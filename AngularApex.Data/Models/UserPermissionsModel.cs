using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Data
{
    /// <summary>
    /// Permissions dedicated based on roles.
    /// </summary>
    public class UserPermissionsModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NormalizedName { get; set; }

        public UserRolesModel UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
