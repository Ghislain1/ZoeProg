using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZoeProg.WebApi.Models
{
    /// [Serializable, element("ook")]

    public class Book
    {
        [XmlElement("author")]
        public string Author { get; set; }

        public bool IsComplete { get; set; }

        public string Lang { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("year")]
        public long Year { get; set; }
    }
}