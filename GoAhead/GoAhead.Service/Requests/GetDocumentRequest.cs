using GoAhead.Contracts;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    [Route("/documents/{Id}", Verbs = "GET")]
    public class GetDocumentRequest : GetDocument, IReturn<Document>
    {
    }
}
