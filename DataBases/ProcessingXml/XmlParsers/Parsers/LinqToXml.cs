using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlParsers.Parsers
{
    public class LinqToXml
    {
        public static string ExtractPricesByYear(string xmlUrl, int minAge)
        {
            var xCatalogue = XDocument.Load(xmlUrl);
            var year = DateTime.Now.Year - minAge;
            var matches = xCatalogue.Descendants("album")
                .Where(node => int.Parse(node.Element("year").Value) < year)
                .Select(node => node.Element("year"))
                .ToList();

            var resultInfo = new StringBuilder();
            foreach (XElement node in matches)
            {
                var parent = node.Parent;
                resultInfo.AppendLine($"Artist: {parent.Element("artist").Value} -- Album: {parent.Element("title").Value} -- Year: {node.Value} -- Price: {parent.Element("price").Value}");
            }

            return resultInfo.ToString();
        }

        public static void CreateXmlDocFromTxt(string xmlUrl, string outputUrl)
        {
            var textLines = File.ReadAllLines(xmlUrl);
            var name = textLines[0];
            var address = textLines[1];
            var phone = textLines[2];

            var idXml = new XElement(
                "personID",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phone", phone));

            idXml.Save(outputUrl);
        }

        public static string ExtractSongTitles(string xmlUrl)
        {
            var xCatalogue = XDocument.Load(xmlUrl);
            var songs = xCatalogue.Descendants("song")
                .Select(song => song.Element("title").Value)
                .ToList();

            return string.Join("\n", songs);
        }
    }
}
