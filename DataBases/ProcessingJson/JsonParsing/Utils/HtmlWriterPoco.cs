using System.IO;
using System.Text;
using System.Web.UI;
using JsonParsing.Models;

namespace JsonParsing.Utils
{
    public class HtmlWriterPoco
    {
        public static void CreateHtmlPage(YouTubeChannel channel, string outputUrl)
        {
            var stringWriter = new StringWriter();

            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Html);

                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                writer.RenderBeginTag(HtmlTextWriterTag.Title);
                writer.Write("Telerik Academy Videos");
                writer.RenderEndTag();
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Body);
                foreach (var video in channel.Videos)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, "height: 500px; width: 600px; text-align: center;");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    writer.AddAttribute(HtmlTextWriterAttribute.Width, "600px");
                    writer.AddAttribute(HtmlTextWriterAttribute.Height, "400px;");
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, "display:block; margin-bottom: 15px;");
                    writer.AddAttribute(HtmlTextWriterAttribute.Src, $"https://www.youtube.com/embed/{video.VideoID}");
                    writer.RenderBeginTag(HtmlTextWriterTag.Iframe);
                    writer.RenderEndTag();
                    
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, $"{video.Link}");
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, $"padding: 10px; margin: 10px; background-color: red; color: white; text-decoration: none; font-size: 15px; border-radius: 4px;");
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("YouTube Link");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }

                writer.RenderEndTag();
                writer.RenderEndTag();
            }

            File.WriteAllText(outputUrl, stringWriter.ToString(), Encoding.Unicode);
            stringWriter.Dispose();
        }
    }
}
