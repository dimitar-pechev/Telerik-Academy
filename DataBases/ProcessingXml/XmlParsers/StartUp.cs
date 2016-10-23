using System;
using XmlParsers.DirectoryIterators;
using XmlParsers.Parsers;
using XmlParsers.Validators;

namespace DomParser
{
    public class StartUp
    {
        public static void Main()
        {
            var catalogueXml = "../../XMLs/catalogue.xml";

            // Task 2. Write program that extracts all different artists which are found in the catalog.xml. 
            Console.WriteLine(CustomDomParser.GetAlbumsCount(catalogueXml));

            // Task 3. Implement the previous using XPath.
            Console.WriteLine(XPath.GetAlbumsCount(catalogueXml));

            // Task 4. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
            var strippedCatalogueDom = CustomDomParser.DeleteAlbumsHigherThanSpecifiedPrice(catalogueXml, 20);

            // Task 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
            Console.WriteLine(StaxParser.ExtractSongTitles(catalogueXml));

            // Task 6. Rewrite the same using XDocument and LINQ query.
            Console.WriteLine(LinqToXml.ExtractSongTitles(catalogueXml));

            // Task 7. In a text file we are given the name, address and phone number of given person(each at a single line).
            var personDataTxt = "../../XMLs/person-id-info.txt";
            var personXml = "../../XMLs/person-id.xml";
            LinqToXml.CreateXmlDocFromTxt(personDataTxt, personXml);

            // Task 8. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates
            // the file album.xml, in which stores in appropriate way the names of all albums and their authors.
            var albumXml = "../../XMLs/albums.xml";
            StaxParser.ExtractAlbums(catalogueXml, albumXml);

            // Task 9. Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. 
            // Set to traverse the Desktop. Try it out with any directory.
            var targetDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outputUrlXmlWriter = "../../XMLs/directory-xml-writer.xml";
            DirectoryIterator.TraverseXmlWriter(targetDirectory, outputUrlXmlWriter);

            // Task 10. Rewrite the last exercises using XDocument, XElement and XAttribute.
            // Set to traverse the Desktop. Try it out with any directory.
            var outputUrlXDoc = "../../XMLs/directory-xdoc.xml";
            DirectoryIterator.TraverseXDoc(targetDirectory, outputUrlXDoc);

            // Task 11. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
            Console.WriteLine(XPath.ExtractPricesByYear(catalogueXml, 15));

            // Task 12. Rewrite the previous using LINQ query.
            Console.WriteLine(LinqToXml.ExtractPricesByYear(catalogueXml, 15));

            // Task 14. Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
            var catalogueXslt = "../../XMLs/catalogue-template.xslt";
            var catalogueHtml = "../../XMLs/catalogue.html";
            XsltConvertor.GenerateHtmlPageForCatalogueXml(catalogueXml, catalogueXslt, catalogueHtml);

            // Task 16. Using Visual Studio generate an XSD schema for the file catalog.xml.
            var catalogueXsd = "../../XMLs/catalogue.xsd";
            Console.WriteLine(XsdValidator.ValidateXml(catalogueXml, catalogueXsd));
            Console.WriteLine(XsdValidator.ValidateXml(personXml, catalogueXsd));
        }
    }
}
