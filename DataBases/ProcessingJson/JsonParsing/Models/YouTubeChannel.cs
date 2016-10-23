using System.Collections.Generic;

namespace JsonParsing.Models
{
    public class YouTubeChannel
    {
        public YouTubeChannel(string title, string url, IList<Video> videos)
        {
            this.Title = title;
            this.Url = url;
            this.Videos = videos;
        }

        public string Title { get; set; }

        public string Url { get; set; }

        public IList<Video> Videos { get; set; }
    }
}
