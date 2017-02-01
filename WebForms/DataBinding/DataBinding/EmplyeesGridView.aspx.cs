using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmplyeesGridView : Page
    {
        NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var employees = this.db.Employees
                    .OrderBy(x => x.EmployeeID)
                    .Select(x => new { FullName = x.FirstName + " " + x.LastName, Url = "/Employees/" + x.EmployeeID })
                    .ToList();

                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void GridViewEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewEmployees.PageIndex = e.NewPageIndex;
            this.GridViewEmployees.DataSource = this.db.Employees
                    .OrderBy(x => x.EmployeeID)
                    .Select(x => new { FullName = x.FirstName + " " + x.LastName, Url = "/Employees/" + x.EmployeeID })
                    .ToList();
            this.GridViewEmployees.DataBind();
        }
    }
}