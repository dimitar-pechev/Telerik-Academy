using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WorkingWithData.Data;
using WorkingWithData.Models;

[assembly: OwinStartupAttribute(typeof(WorkingWithData.Startup))]
namespace WorkingWithData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
  
            if (!roleManager.RoleExists("user"))
            {
                var role = new IdentityRole();
                role.Name = "user";
                roleManager.Create(role);

            }
        }
    }
}
