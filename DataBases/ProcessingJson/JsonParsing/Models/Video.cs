using System;

namespace JsonParsing.Models
{
    public class Video
    {
        public Video(string title, string author, string videoID, string link, DateTime datePublished)
        {
            this.Title = title;
            this.Author = author;
            this.VideoID = videoID;
            this.Link = link;
            this.DatePublished = datePublished;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string VideoID { get; set; }

        public string Link { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
