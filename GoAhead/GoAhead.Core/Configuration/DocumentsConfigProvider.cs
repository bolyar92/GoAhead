using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GoAhead.Core.Configuration
{
    public class DocumentsConfigProvider : IDocumentsConfigProvider
    {
        private string configPath;

        public DocumentsConfigProvider(string configPath)
        {
            this.configPath = configPath;
        }

        public DocumentsConfiguration ReadConfiguration()
        {
            var serializer = new XmlSerializer(typeof(DocumentsConfiguration));
            using (var reader = new StreamReader(this.configPath))
            {
                return (DocumentsConfiguration)serializer.Deserialize(reader);
            }
        }
    }
}
