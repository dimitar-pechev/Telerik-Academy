using System;
using System.Linq;
using System.Net;
using System.Xml;

using JsonParsing.Models;
using JsonParsing.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonParsing
{
    public class StartUp
    {
        public static void Main()
        {
            var webClient = new WebClient();
            var address = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var xmlUrl = "../../telerik-academy-rss.xml";
            webClient.DownloadFile(address, xmlUrl);

            var doc = new XmlDocument();
            doc.Load(xmlUrl);
            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

            var telerikRss = JObject.Parse(json)["feed"];

            // Task 4. Using LINQ-to-JSON select all video titles and print them on the console.
            var videoNames = telerikRss["entry"]
                .Children()
                .Select(x => x.Value<string>("title"))
                .ToList();

            Console.WriteLine(string.Join("\n", videoNames));

            // Task 5. Parse the videos' JSON to POCO.
            var videos = telerikRss["entry"]
                .Children()
                .Select(video => new Video((string)video["title"], (string)video["author"]["name"], (string)video["yt:videoId"], (string)video["link"]["@href"], (DateTime)video["published"]))
                .ToList();
            
            var telerikChannel = new YouTubeChannel((string)telerikRss["title"], (string)telerikRss["link"][0]["@href"], videos);

            // Task 6. Using the POCOs create a HTML page that shows all videos from the RSS.
            // Html located in the project folder!
            var htmlOutputUrl = "../../telerik-academy-youtube.html";
            HtmlWriterPoco.CreateHtmlPage(telerikChannel, htmlOutputUrl);
        }
    }
}
