using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class DummyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Request.Cookies.AllKeys.Contains("username"))
            {
                this.Response.Redirect("~/DummyLogin.aspx");
            }
        }
    }
}