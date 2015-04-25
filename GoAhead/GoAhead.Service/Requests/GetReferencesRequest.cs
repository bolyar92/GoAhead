using GoAhead.Contracts;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    [Route("/documents/{ForDocumentId}/references", Verbs = "GET")]
    public class GetReferencesRequest : GetReferences, IReturn<List<Reference>>
    {
    }
}
