using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class Calculator : Page
    {
        private static bool ShouldErase;
        private static string PrevValue;
        private static string PrevSign;
        private static string PrevNumber;
        private static bool ShouldEraseAfterEql;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            double number;
            var isNumber = double.TryParse(e.CommandName, out number);

            if (string.IsNullOrEmpty(this.ResultContainer.Text) && !isNumber)
            {
                return;
            }

            if (this.ResultContainer.Text == "Invalid input!" && !isNumber)
            {
                this.ResultContainer.Text = string.Empty;
                return;
            }

            if (ShouldErase)
            {
                this.ResultContainer.Text = string.Empty;
                ShouldErase = false;
            }

            if ((isNumber || e.CommandName == ".") && ShouldEraseAfterEql && e.CommandName != "sqrt")
            {
                this.ResultContainer.Text = string.Empty;
                PrevNumber = string.Empty;
            }

            ShouldEraseAfterEql = false;

            if (isNumber || e.CommandName == ".")
            {
                var length = this.ResultContainer.Text.Length;
                if (length >= 15 || (this.ResultContainer.Text.IndexOf(".") >= 0 && e.CommandName == "."))
                {
                    return;
                }

                this.ResultContainer.Text += e.CommandName;
                PrevNumber = this.ResultContainer.Text;
            }
            else
            {
                double currentNumber = 0;
                if (!string.IsNullOrEmpty(this.ResultContainer.Text))
                {
                    currentNumber = double.Parse(this.ResultContainer.Text);
                }

                double prevValue;
                if (string.IsNullOrEmpty(PrevValue))
                {
                    prevValue = 0;
                }
                else
                {
                    prevValue = double.Parse(PrevValue);
                }

                double result = currentNumber;
                if (!string.IsNullOrEmpty(PrevSign))
                {
                    result = Calculate(PrevSign, currentNumber, prevValue);
                    if (double.IsNaN(result) || double.IsInfinity(result))
                    {
                        this.ResultContainer.Text = "Invalid input!";
                        ShouldErase = true;
                        PrevValue = string.Empty;
                        PrevSign = string.Empty;
                        PrevNumber = string.Empty;
                        return;
                    }
                }

                switch (e.CommandName)
                {
                    case "sqrt":
                        if (result < 0)
                        {
                            this.ResultContainer.Text = "Invalid input!";
                            ShouldErase = true;
                            PrevValue = string.Empty;
                            PrevSign = string.Empty;
                            PrevNumber = string.Empty;
                            break;
                        }

                        result = Math.Sqrt(result);
                        ShouldEraseAfterEql = true;
                        PrevValue = result.ToString();
                        PrevSign = string.Empty;
                        this.ResultContainer.Text = result.ToString();
                        PrevNumber = this.ResultContainer.Text;
                        break;
                    case "clear":
                        ShouldErase = false;
                        PrevValue = string.Empty;
                        this.ResultContainer.Text = string.Empty;
                        PrevSign = string.Empty;
                        PrevNumber = string.Empty;
                        break;
                    case "eqls":
                        this.ResultContainer.Text = result.ToString();
                        ShouldErase = false;
                        ShouldEraseAfterEql = true;
                        PrevValue = result.ToString();
                        PrevSign = string.Empty;
                        break;
                    default:
                        ShouldErase = true;
                        PrevValue = result.ToString();
                        this.ResultContainer.Text = result.ToString();
                        PrevSign = e.CommandName;
                        PrevNumber = string.Empty;
                        break;
                }
            }
        }

        private static double Calculate(string lastSign, double currentValue, double prevValue)
        {
            double result;
            switch (lastSign)
            {
                case "add":
                    result = prevValue + currentValue;
                    return result;
                case "subst":
                    result = prevValue - currentValue;
                    return result;
                case "multiply":
                    if (PrevNumber == "0")
                    {
                        currentValue = 0;
                    }
                    else if (currentValue == 0)
                    {
                        currentValue = 1;
                    }

                    result = prevValue * currentValue;
                    return result;
                case "divide":
                    if (PrevNumber == "0" || prevValue == 0)
                    {
                        currentValue = 0;
                    }
                    else if (currentValue == 0)
                    {
                        currentValue = 1;
                    }

                    result = prevValue / currentValue;
                    return result;
                default: return 0;
            }
        }
    }
}