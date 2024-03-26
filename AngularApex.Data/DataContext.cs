using AngularApex.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularApex.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<RegisterUserModel> UserAccounts { get; set; }
    }
}
