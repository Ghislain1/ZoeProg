using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZoeProg.WebApi.Models;

namespace ZoeProg.WebApi.Services
{
    public class SerializeService : ISerializeService
    {
        public BookStore Deserialize(string fileName)
        {
            // Create an instance of the XmlSerializer class; specify the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(BookStore));
            /* If the XML document has been altered with unknown
            nodes or attributes, handle them with the
            UnknownNode and UnknownAttribute events.*/
            serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(fileName, FileMode.Open);
            // Declare an object variable of the type to be deserialized.
            BookStore po;

            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            po = (BookStore)serializer.Deserialize(fs);
            fs.Close();
            return po;
        }

        public void Serialize(BookStore bookStore, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BookStore));
            TextWriter writer = new StreamWriter(fileName);

            // Serialize the purchase order, and close the TextWriter.
            serializer.Serialize(writer, bookStore);
            writer.Close();
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }
    }
}