## XML Basics
### _Homework_

1.  What does the XML language represent? What is it used for? 
  * Extensible Markup Language is a standard defining specific syntax for storing data. It uses tags, similar to html tags though there are no restrictions on the types of tags unless an XML Schema is applied. 
  * Main pros: human readable and can be very descriptive through attributes.
  * Main cons: xml files are larger in size compared to JSON files for example. 
1.  Create XML document `students.xml`, which contains structured description of students.
  * For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).
1.  What do namespaces represent in an XML document? What are they used for? 
  * Namespaces provide a way to use a the same tag name in different contexts. It works as disambiguation tool. E.g. 'namespace1:tagName' and 'namespace2:tagName' are considered as different tag names. 
1.  Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.
1.  Add default namespace for students "`urn:students`".
1.  Create XSD Schema for `students.xml` document.
  * Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.
1.  Write an XSL stylesheet to visualize the students as HTML.
  * Test it in your favourite browser.
