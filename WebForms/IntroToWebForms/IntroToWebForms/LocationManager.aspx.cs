using System;
using System.Reflection;
using System.Web.UI;

namespace IntroToWebForms
{
    public partial class LocationManager : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLocation_Click(object sender, EventArgs e)
        {
            this.LocationBox.InnerHtml = Assembly.GetExecutingAssembly().Location.ToString();
        }
    }
}