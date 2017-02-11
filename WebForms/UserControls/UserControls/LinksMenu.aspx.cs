using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControls
{
    public partial class LinksMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new List<Link>()
            {
                new UserControls.Link { Url = "/DummyPages/Home.aspx", Title = "Home" },
                new UserControls.Link { Url = "/DummyPages/About.aspx", Title = "About" },
                new UserControls.Link { Url = "/DummyPages/Contacts.aspx", Title = "Contacts" },
                new UserControls.Link { Url = "/DummyPages/Content.aspx", Title = "Awesome Content" }
            };
            this.MyListMenu.DataSource = list;
            this.MyListMenu.DataBind();
        }
    }
}