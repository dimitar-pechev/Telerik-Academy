using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlParsers.Parsers
{
    public class XPath
    {
        public static string GetAlbumsCount(string xmlUrl)
        {
            var doc = new XmlDocument();
            doc.Load(xmlUrl);
            var catalogue = doc.DocumentElement;
            var artists = new Hashtable();

            var currentArtistQuery = "/catalogue/album/artist";
            var currentAlbumNameQuery = "/catalogue/album/title";

            var navigator = catalogue.CreateNavigator();
            var artist = navigator.Select(currentArtistQuery);
            var album = navigator.Select(currentAlbumNameQuery);

            while (artist.MoveNext() && album.MoveNext())
            {
                if (artists.ContainsKey(artist.Current.InnerXml))
                {
                    var currentAlbum = (List<string>)artists[artist.Current.InnerXml];
                    currentAlbum.Add(album.Current.InnerXml);
                    artists[artist.Current.InnerXml] = currentAlbum;
                }
                else
                {
                    var albums = new List<string>() { album.Current.InnerXml };
                    artists.Add(artist.Current.InnerXml, albums);
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

        public static string ExtractPricesByYear(string xmlUrl, int minAge)
        {
            var doc = new XmlDocument();
            doc.Load(xmlUrl);
            var year = DateTime.Now.Year - minAge;
            var priceQuery = $"/catalogue/album/year[text() < {year}]";
            var matches = doc.SelectNodes(priceQuery);

            var resultInfo = new StringBuilder();
            foreach (XmlNode node in matches)
            {
                var parent = node.ParentNode;
                resultInfo.AppendLine($"Artist: {parent["artist"].InnerText} -- Album: {parent["title"].InnerText} -- Year: {node.InnerText} -- Price: {parent["price"].InnerText}");
            }

            return resultInfo.ToString();
        }
    }
}
