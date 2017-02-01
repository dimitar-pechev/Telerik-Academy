using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmployeesFormView : Page
    {
        private NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = this.db.Employees.ToList();
            this.FormViewEmployees.DataSource = employees;
            this.FormViewEmployees.DataBind();
        }

        protected void FormViewEmployees_PageIndexChanging1(object sender, FormViewPageEventArgs e)
        {
            this.FormViewEmployees.PageIndex = e.NewPageIndex;
            this.FormViewEmployees.DataSource = this.db.Employees.ToList();
            this.FormViewEmployees.DataBind();
        }
    }
}