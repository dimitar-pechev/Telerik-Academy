using System;
using System.Reflection;
using System.Web.UI;

namespace IntroToWebForms
{
    public partial class GreetingsManager : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Name.Text.Trim()))
            {
                this.Greeting.InnerHtml = $"Hello, {this.Name.Text}!";
            }
        }
    }
}