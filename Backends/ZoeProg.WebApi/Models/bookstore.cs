using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZoeProg.WebApi.Models
{
    [Serializable, XmlRoot("bookstore")]
    public class BookStore
    {
        public BookStore()
        {
        }

        [XmlElement("book")]
        public Book[] Books { get; set; }

        // public long Year { get; set; }
    }
}