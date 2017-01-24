using System;
using System.Web.UI;

namespace Sumator
{
    public partial class Sumator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var firstValue = double.Parse(this.firstValue.Value);
                var secondValue = double.Parse(this.secondValue.Value);
                var sum = firstValue + secondValue;
                this.sum.InnerHtml = "Sum: " + sum.ToString();
            }
            catch (Exception)
            {
                this.sum.InnerHtml = "Input value was not in the correct format!";
            }
        }
    }
}