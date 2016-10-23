using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlParsers.Parsers
{
    public class CustomDomParser
    {
        public static string GetAlbumsCount(string xmlUrl)
        {
            var doc = new XmlDocument();
            doc.Load(xmlUrl);
            var catalogue = doc.DocumentElement;

            var artists = new Hashtable();
            foreach (XmlNode album in catalogue)
            {
                var currentArtist = album["artist"].InnerText;
                if (artists.ContainsKey(currentArtist))
                {
                    var currentAlbum = (List<string>)artists[currentArtist];
                    currentAlbum.Add(album["title"].InnerText);
                    artists[currentArtist] = currentAlbum;
                }
                else
                {
                    var albums = new List<string>() { album["title"].InnerText };
                    artists.Add(album["artist"].InnerText, albums);
                }
            }

            var resultInfo = new StringBuilder();
            foreach (DictionaryEntry entry in artists)
            {
                var albums = (List<string>)entry.Value;
                resultInfo.AppendLine($"{entry.Key} => Albums count: {albums.Count} ({string.Join(", ", albums)})");
            }

            return resultInfo.ToString();
        }

        public static XmlNode DeleteAlbumsHigherThanSpecifiedPrice(string xmlUrl, double price)
        {
            var doc = new XmlDocument();
            doc.Load(xmlUrl);
            var catalogue = doc.DocumentElement;

            foreach (XmlNode album in catalogue)
            {
                if (double.Parse(album["price"].InnerText) > price)
                {
                    catalogue.RemoveChild(album);
                }
            }

            return catalogue;
        }        
    }
}
