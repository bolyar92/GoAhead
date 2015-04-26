using GoAhead.Contracts;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    [Route("/collections", Verbs = "GET")]
    public  class GetCollectionsRequest : GetCollections, IReturn<string[]>
    {
    }
}
