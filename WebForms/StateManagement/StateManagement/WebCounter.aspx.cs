using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement
{
    public partial class WebCounter : System.Web.UI.Page
    {
        private const string Visits = "visits";

        protected void Page_Load(object sender, EventArgs e) 
        {
            if (this.Application[Visits] == null)
            {
                this.Application[Visits] = 1;
            }
            else
            {
                this.Application[Visits] = int.Parse(this.Application[Visits].ToString()) + 1;
            }

            var widht = 300;
            if (int.Parse(this.Application[Visits].ToString()) > 9)
            {
                widht = 480;
            }

            var imageGenerator = new BitmapGenerator();
            var image = imageGenerator.GenerateImage(this.Application[Visits].ToString(), "Roboto", Color.FromArgb(59, 89, 152), 180, Color.White, widht, 330);
            image.Save(this.Server.MapPath("/Temp/temp.png"), ImageFormat.Png);

            this.CounterImage.ImageUrl = "/Temp/temp.png"; 
        }
    }
}