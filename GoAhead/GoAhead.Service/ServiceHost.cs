using GoAhead.Core;
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
        public ServiceHost() : base("Documents Web Services", typeof(DocumentsService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            SetConfig(new HostConfig { HandlerFactoryPath = "api" });

            container.RegisterAutoWiredAs<DummyDocumentsManager, IDocumentsManager>()
                .ReusedWithin(Funq.ReuseScope.Request);
        }
    }
}
