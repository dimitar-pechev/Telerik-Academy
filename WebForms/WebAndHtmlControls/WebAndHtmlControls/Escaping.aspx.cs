using System;
using System.Web.UI;

namespace WebAndHtmlControls
{
    public partial class Escaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            this.Result.Text = this.InputBox.Text;
        }
    }
}