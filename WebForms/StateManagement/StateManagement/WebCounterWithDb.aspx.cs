using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace StateManagement
{
    public partial class WebCounterWithDb : Page
    {
        private const string Visits = "visits";

        protected void Page_Load(object sender, EventArgs e)
        {
            var visits = string.Empty;
            if (!this.Request.Cookies.AllKeys.Contains(Visits))
            {
                var cookie = new HttpCookie(Visits, "1");
                this.Response.Cookies.Add(cookie);
                visits = "1";
            }
            else
            {
                var cookie = new HttpCookie(Visits, (int.Parse(this.Request.Cookies[Visits].Value) + 1).ToString());
                this.Response.Cookies.Add(cookie);
                visits = (int.Parse(this.Request.Cookies[Visits].Value) + 1).ToString();
            }

            var font = "Roboto";
            var fontSize = 180;
            var height = 330;
            var widht = 300;
            if (int.Parse(visits) > 9)
            {
                widht = 480;
            }

            var imageGenerator = new BitmapGenerator();
            var image = imageGenerator.GenerateImage(visits, font, Color.FromArgb(59, 89, 152), fontSize, Color.White, widht, height);
            image.Save(this.Server.MapPath("/Temp/tempDb.png"), ImageFormat.Png); 

            this.CounterImageDb.ImageUrl = "/Temp/tempDb.png";
        }
    }
}