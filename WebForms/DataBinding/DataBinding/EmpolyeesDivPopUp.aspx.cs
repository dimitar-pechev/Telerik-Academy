using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class EmpolyeesDivPopUp : Page
    {
        private static NorthwindEntities db = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = db.Employees.ToList();
            this.ListViewEmployeesPopUp.DataSource = employees;
            this.ListViewEmployeesPopUp.DataBind();
        }

        [WebMethod]
        public static object GetEmployeeByID(string id)
        {
            int parsedId = int.Parse(id);
            var employee = db.Employees.FirstOrDefault(x => x.EmployeeID == parsedId);

            return new
            {
                Name = $"{employee.FirstName} {employee.LastName}",
                Phone = employee.HomePhone,
                Address = employee.Address,
                Notes = employee.Notes
            };
        }
    }
}