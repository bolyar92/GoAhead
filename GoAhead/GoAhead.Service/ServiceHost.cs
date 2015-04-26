using GoAhead.Core;
using GoAhead.Core.Configuration;
using GoAhead.Data;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace GoAhead.Service
{
    public class ServiceHost : AppHostBase
    {
        private string ConfigurationPath
        {
            get
            {
                return ConfigurationManager.AppSettings["DocumentsConfigPath"];
            }
        }

        public ServiceHost()
            : base("Documents Web Services", typeof(DocumentsService).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
            SetConfig(new HostConfig { HandlerFactoryPath = "api" });

            JsConfig.EmitLowercaseUnderscoreNames = true;

            container.Register<IDocumentsConfigProvider>(c => new DocumentsConfigProvider(this.ConfigurationPath))
                .ReusedWithin(Funq.ReuseScope.Request);
            container.RegisterAutoWiredAs<MongoDataProvider, IDataProvider>()
                .ReusedWithin(Funq.ReuseScope.Request);
            container.RegisterAutoWiredAs<DocumentsManager, IDocumentsManager>()
                .ReusedWithin(Funq.ReuseScope.Request);
        }
    }
}
