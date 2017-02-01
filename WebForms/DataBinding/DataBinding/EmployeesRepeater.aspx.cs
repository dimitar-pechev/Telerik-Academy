using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmployeesRepeater : System.Web.UI.Page
    {
        private NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = this.db.Employees.ToList();
            this.RepeaterEmployees.DataSource = employees;
            this.RepeaterEmployees.DataBind();
        }

    }
}