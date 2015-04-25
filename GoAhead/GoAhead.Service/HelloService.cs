using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    public class HelloService : ServiceStack.Service
    {
        public object Any(HelloRequest request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    } 
}
