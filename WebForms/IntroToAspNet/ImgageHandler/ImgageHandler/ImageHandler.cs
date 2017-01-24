using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace ImageHandler
{
    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            // To get an image with custom text you must add the desired string following the url as a query param 
            // (e.g. "localhost:...../random.img?text=Facebook").
            // Otherwise you get as default text what you set below.
            var text = context.Request.Params["text"];
            if (string.IsNullOrEmpty(text))
            {
                text = "Facebook";
            }

            var image = ConvertToImage(text, "Roboto", Color.FromArgb(59, 89, 152), 25, Color.White, 1920, 50);

            context.Response.ContentType = "image/png";
            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        public Bitmap ConvertToImage(string text, string fontName, Color backgroundColor, int fontSize, Color fontColor, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(fontName, fontSize);

            graphics.FillRectangle(new SolidBrush(backgroundColor), 0, 0, bitmap.Width, bitmap.Height);
            graphics.DrawString(text, font, new SolidBrush(fontColor), 0, 0);
            font.Dispose();
            graphics.Dispose();

            return bitmap;
        }
    }
}