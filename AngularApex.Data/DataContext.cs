using AngularApex.Data.Data;
using AngularApex.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularApex.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<RegisterUserModel> UserAccounts { get; set; }
        public DbSet<UserRolesModel> UserRoles { get; set; }
        public DbSet<UserPermissionsModel> UserPermissions { get; set; }
        public DbSet<UserRoleAssigmentModel> UserRoleAssigments { get; set; }
    }
}
