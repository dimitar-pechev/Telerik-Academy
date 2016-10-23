using System.Xml.Xsl;

namespace XmlParsers.Parsers
{
    public class XsltConvertor
    {
        public static void GenerateHtmlPageForCatalogueXml(string xmlUrl, string xsltUrl, string resultHtmlPath)
        {
            var convertor = new XslTransform();
            convertor.Load(xsltUrl);
            convertor.Transform(xmlUrl, resultHtmlPath);
        }
    }
}
