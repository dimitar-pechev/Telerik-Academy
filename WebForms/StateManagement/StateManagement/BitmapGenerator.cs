using System.Drawing;

namespace StateManagement
{
    public class BitmapGenerator
    {
        public Bitmap GenerateImage(string text, string fontName, Color backgroundColor, int fontSize, Color fontColor, int width, int height)
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