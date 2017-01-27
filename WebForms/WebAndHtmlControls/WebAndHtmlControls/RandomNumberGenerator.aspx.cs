using System;
using System.Web.UI;

namespace WebAndHtmlControls
{
    public partial class RandomNumberGenerator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HtmlBtnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var firstValue = int.Parse(this.randomFrom.Value);
                var secondtValue = int.Parse(this.randomUntil.Value);
                var random = new Random();
                var result = random.Next(firstValue, secondtValue);
                this.HtmlResult.InnerHtml = $"Random: {result}";
            }
            catch (Exception)
            {
                this.HtmlResult.InnerHtml = "Input data was not in the correct format!";
            }
        }

        protected void WebBtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var firstValue = int.Parse(this.webRandomFrom.Text);
                var secondtValue = int.Parse(this.webRandomUntil.Text);
                var random = new Random();
                var result = random.Next(firstValue, secondtValue);
                this.WebResult.Text = $"Random: {result}";
            }
            catch (Exception)
            {
                this.WebResult.Text = "Input data was not in the correct format!";
            }
        }
    }
}