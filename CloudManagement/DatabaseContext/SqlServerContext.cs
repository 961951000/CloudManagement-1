using System.Data.Entity;
using CloudManagement.Models;

namespace CloudManagement.DatabaseContext
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() : base("name=SqlServerConnection") { }

        public DbSet<City> City { get; set; }

        public DbSet<CompanyCategory> CompanyCategory { get; set; }

        public DbSet<CompanyNature> CompanyNature { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Province> Province { get; set; }

        public DbSet<RoleNature> RoleNature { get; set; }

        public DbSet<User> User { get; set; }
    }
}
