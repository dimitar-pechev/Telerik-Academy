using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class Sessions : System.Web.UI.Page
    {
        private const string SessionStorageStrings = "strings";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && this.Session[SessionStorageStrings] != null)
            {
                PopulatePanelFromSession();
            }
        }

        protected void BtnAddToStorage_Click(object sender, EventArgs e)
        {
            if (this.Session[SessionStorageStrings] == null)
            {
                this.Session[SessionStorageStrings] = new List<string>();
            }

            if (string.IsNullOrEmpty(this.InputText.Text.Trim()))
            {
                return;
            }

            (this.Session[SessionStorageStrings] as List<string>).Add(this.InputText.Text.Trim());
            this.InputText.Text = string.Empty;

            PopulatePanelFromSession();
        }

        private void PopulatePanelFromSession()
        {
            foreach (var str in (this.Session[SessionStorageStrings] as List<string>))
            {
                var label = new Label();
                label.Text = $"{str}<br />";
                this.PanelStrings.Controls.Add(label);
            }
        }
    }
}