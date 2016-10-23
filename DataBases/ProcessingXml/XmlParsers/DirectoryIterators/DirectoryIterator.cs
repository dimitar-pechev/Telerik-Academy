using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlParsers.DirectoryIterators
{
    public class DirectoryIterator
    {
        public static void TraverseXmlWriter(string targetDirectory, string outputUrl)
        {
            Console.WriteLine("\nTraversing the provided directory and writing it down via XmlWriter. This may take a while...\n");
            var settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            settings.Indent = true;
            using (var writer = XmlWriter.Create(outputUrl, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("directory");
                TraverseDirectoryXmlWriter(writer, targetDirectory);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static void TraverseXDoc(string targetDirectory, string outputUrl)
        {
            Console.WriteLine("Traversing the provided directory and writing it down via XDocument. This may take a while...\n");
            var xDoc = new XElement("directory");
            var xElement = TraverseDirectoryXDoc(targetDirectory);
            xDoc.Add(xElement);
            xDoc.Save(outputUrl);
        }

        private static void TraverseDirectoryXmlWriter(XmlWriter writer, string targetDirectory)
        {
            foreach (var directory in Directory.GetDirectories(targetDirectory))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                TraverseDirectoryXmlWriter(writer, directory);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(targetDirectory))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileName(file));
                writer.WriteEndElement();
            }
        }

        private static XElement TraverseDirectoryXDoc(string targetDirectory)
        {
            var xElement = new XElement("dir", new XAttribute("path", targetDirectory));

            foreach (var directory in Directory.GetDirectories(targetDirectory))
            {
                xElement.Add(TraverseDirectoryXDoc(directory));
            }

            foreach (var file in Directory.GetFiles(targetDirectory))
            {
                xElement.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("ext", Path.GetExtension(file))));
            }

            return xElement;
        }   
    }
}
