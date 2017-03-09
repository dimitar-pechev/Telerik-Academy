namespace WorkingWithData.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WorkingWithData.Models.ApplicationDbContext";
        }

        protected override void Seed(Models.ApplicationDbContext context)
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
