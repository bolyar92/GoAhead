using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    public class ServiceHost : AppHostBase
    {
        //Tell ServiceStack the name of your application and where to find your services
        public ServiceHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            SetConfig(new HostConfig { HandlerFactoryPath = "api" });

            //register any dependencies your services use, e.g:
            //container.Register<ICacheClient>(new MemoryCacheClient());
        }

        //Initialize your application singleton
        protected void Application_Start(object sender, EventArgs e)
        {
            new ServiceHost().Init();
        }
    }
}
