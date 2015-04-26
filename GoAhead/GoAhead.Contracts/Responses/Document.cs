using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Contracts
{
    public class Document
    {
        public string Id { get; set; }
        public string RawJsonValue { get; set; }
        public List<Reference> References { get; set; }

        public Document()
        {
            this.References = new List<Reference>();
        }
    }
}
