using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class UserAgent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetUserInfo_Click(object sender, EventArgs e)
        {
            this.BrowserType.Text = $"<b>Browser Type:</b> {this.Request.Browser.Type}";
            this.UserIp.Text = $"<b>User IP:</b> {this.Request.UserHostAddress}";
        }
    }
}