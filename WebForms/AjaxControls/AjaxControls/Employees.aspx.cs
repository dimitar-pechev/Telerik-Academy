using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxControls
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void GridViewEmployees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Thread.Sleep(3000);
        }
    }
}