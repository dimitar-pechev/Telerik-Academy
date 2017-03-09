namespace WorkingWithData.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WorkingWithData.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //// Seeding initail roles
            //var admin = new IdentityRole("admin");
            //var user = new IdentityRole("user");

            //context.Roles.Add(admin);
            //context.Roles.Add(user);

            //context.SaveChanges();
        }
    }
}
