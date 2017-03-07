using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxWithAspNetMvc.Startup))]
namespace AjaxWithAspNetMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
