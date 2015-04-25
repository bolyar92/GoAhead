using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class HelloRequest
    {
        public string Name { get; set; }
    }
}
