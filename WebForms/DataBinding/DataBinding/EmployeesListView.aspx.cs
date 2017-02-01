using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmployeesListView : Page
    {
        private NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewEmployees.DataSource = this.db.Employees.ToList();
            this.ListViewEmployees.DataBind();
        }
    }
}