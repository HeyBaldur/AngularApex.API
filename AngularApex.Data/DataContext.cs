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

        // CRM Props
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
