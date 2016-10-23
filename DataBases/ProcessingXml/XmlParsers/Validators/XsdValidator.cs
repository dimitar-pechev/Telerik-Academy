using System.Xml.Linq;
using System.Xml.Schema;

namespace XmlParsers.Validators
{
    public class XsdValidator
    {
        public static string ValidateXml(string xmlUrl, string xsdUrl)
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, xsdUrl);

            var doc = XDocument.Load(xmlUrl);

            var result = "XML is valid! Matches the XSD correctly!";
            doc.Validate(schema, (obj, ev) =>
            {
                if (!string.IsNullOrEmpty(ev.Message))
                {
                    result = "XML is INVALID! Does not follow the rules set by the XSD!";
                }
            });

            return result;
        }
    }
}
