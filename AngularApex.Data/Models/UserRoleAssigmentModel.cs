using AngularApex.Data.Models;

namespace AngularApex.Data.Data
{
    public class UserRoleAssigmentModel
    {
        public int Id { get; set; }
        public RegisterUserModel UserModel { get; set; }
        public int UserModelId { get; set; }
        public UserRolesModel UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
