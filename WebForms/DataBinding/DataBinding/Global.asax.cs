using System;
using System.Web;
using System.Web.Routing;

namespace DataBindingHW
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "Employees/{id}", "~/EmployeeDetails.aspx");
        }
    }
}