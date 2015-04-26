using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GoAhead.Core.Configuration
{
    [XmlRoot("documentsConfiguration")]
    public class DocumentsConfiguration
    {
        [XmlArray("documents")]
        [XmlArrayItem("document")]
        public Document[] Documents { get; set; }
    }

    public class Document
    {
        [XmlAttribute("collection")]
        public string Collection { get; set; }

        [XmlArray("referringTo")]
        [XmlArrayItem("reference")]
        public Reference[] ReferringTo { get; set; }
    }

    public class Reference
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("relation")]
        public string Relation { get; set; }

        [XmlAttribute("primaryKey")]
        public string PrimaryKey { get; set; }
    }
}
