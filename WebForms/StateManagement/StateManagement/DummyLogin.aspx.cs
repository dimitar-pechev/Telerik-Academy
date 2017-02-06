using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class DummyLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Cookies.AllKeys.Contains("username"))
            {
                this.Response.Redirect("~/DummyProfile.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Username.Text))
            {
                return;
            }

            var cookie = new HttpCookie("username", this.Username.Text);
            cookie.Expires = DateTime.Now.AddMinutes(1);

            this.Response.AppendCookie(cookie);
            this.Response.Redirect("~/DummyProfile.aspx");
        }
    }
}