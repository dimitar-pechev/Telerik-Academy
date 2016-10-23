using System.Text;
using System.Xml;

namespace XmlParsers.Parsers
{
    public class StaxParser
    {
        public static string ExtractSongTitles(string xmlUrl)
        {
            using (var xmlReader = XmlReader.Create(xmlUrl))
            {
                var resultInfo = new StringBuilder();
                var prevNode = string.Empty;

                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && prevNode == "song" && xmlReader.Name == "title")
                    {
                        resultInfo.AppendLine(xmlReader.ReadElementString());
                    }

                    if (!string.IsNullOrEmpty(xmlReader.Name))
                    {
                        prevNode = xmlReader.Name;
                    }
                }

                return resultInfo.ToString();
            }
        }

        public static void ExtractAlbums(string xmlUrl, string outputUrl)
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            var writer = XmlWriter.Create(outputUrl, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("albums");

            var reader = XmlReader.Create(xmlUrl);
            var isTagOpened = false;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                {
                    writer.WriteStartElement("album");
                    isTagOpened = true;
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "title" && isTagOpened)
                {
                    writer.WriteElementString("title", reader.ReadElementString());
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "artist")
                {
                    writer.WriteElementString("author", reader.ReadElementString());
                    writer.WriteEndElement();
                    isTagOpened = false;
                }
            }

            reader.Dispose();
            writer.Dispose();
        }
    }
}