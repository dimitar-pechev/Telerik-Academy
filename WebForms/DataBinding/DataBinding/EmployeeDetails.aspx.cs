using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmployeeDetails : Page
    {
        private NorthwindEntities db = new NorthwindEntities();
        public string FullName;
        public Employee Employee;

        protected void Page_Load(object sender, EventArgs e)
        {
            var employeeId = int.Parse(this.Page.RouteData.Values["id"].ToString());
            this.Employee = this.db.Employees.FirstOrDefault(x => x.EmployeeID == employeeId);
            this.FullName = $"{Employee.FirstName} {Employee.LastName}";
            this.DetailsViewEmployee.DataSource = new Employee[] { this.Employee };
            this.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmplyeesGridView.aspx");
        }
    }
}