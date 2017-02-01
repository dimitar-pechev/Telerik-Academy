using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingHW
{
    public partial class XmlTreeView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TreeViewXmlReader_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.ResultPlaceHolder.Text = this.TreeViewXmlReader.SelectedNode.Text;
            this.BulletedListResult.Items.Clear();
            foreach (TreeNode item in this.TreeViewXmlReader.SelectedNode.ChildNodes)
            {
                this.BulletedListResult.Items.Add(item.Text);
            }
        }        
    }
}