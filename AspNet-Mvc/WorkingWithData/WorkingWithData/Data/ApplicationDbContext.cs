using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WorkingWithData.Data.Contracts;
using WorkingWithData.Migrations;
using WorkingWithData.Models;

namespace WorkingWithData.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}