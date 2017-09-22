using System.Data.Entity;
using CloudManagement.Models;

namespace CloudManagement.DatabaseContext
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() : base("name=SqlServerConnection") { }

        public DbSet<OperationLog> OperationLog { get; set; }

        public DbSet<OperationType> OperationType { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<RolePermissionMapping> RolePermissionMapping { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Tenant> Tenant { get; set; }

        public DbSet<TenantDetail> TenantDetail { get; set; }

        public DbSet<ThirdPartyService> ThirdPartyService { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserDetail> UserDetail { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<UserGroupRoleMapping> UserGroupRoleMapping { get; set; }

        public DbSet<UserThirdPartyServiceMapping> UserThirdPartyServiceMapping { get; set; }
    }
}
