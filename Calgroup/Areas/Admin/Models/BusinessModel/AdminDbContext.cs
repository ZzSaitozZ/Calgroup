using Calgroup.Areas.Admin.Models.DataModel;
using System.Data.Entity;

namespace Calgroup.Areas.Admin.Models.BusinessModel
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext() : base("name =Calgroup_v2DB")
        {

        }
        public DbSet<UserAdministrator> Administrators { get; set; }
        public DbSet<UserBusiness> Businesseses { get; set; }
        public DbSet<UserCategory> Categories { get; set; }
        public DbSet<UserGrantPermission> GrantPermissions { get; set; }
        public DbSet<UserPermission> Permissions { get; set; }
        public DbSet<UserPost> Posts { get; set; }

    }
}