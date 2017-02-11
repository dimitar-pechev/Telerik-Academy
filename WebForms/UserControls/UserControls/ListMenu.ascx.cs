using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControls
{
    public partial class ListMenu : System.Web.UI.UserControl
    {
        private IEnumerable<ILink> dataSource;
        public IEnumerable<ILink> DataSource
        {
            get
            {
                return this.dataSource;
            }

            set
            {
                this.dataSource = value;
                this.DataListLinks.DataSource = this.DataSource;
            }
        }
                
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}