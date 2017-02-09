using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidationControls
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonsGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.RadioButtonsGender.SelectedValue)
            {
                case "Male":
                    this.DropDownListMale.Visible = true;
                    this.DropDownListFemale.Visible = false;
                    break;
                case "Female":
                    this.DropDownListFemale.Visible = true;
                    this.DropDownListMale.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected void BtnSubmitAll_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationPersonalInfo");
            this.Page.Validate("ValidationLoginInfo");
            this.Page.Validate("ValidationContactsInfo");
        }
    }
}