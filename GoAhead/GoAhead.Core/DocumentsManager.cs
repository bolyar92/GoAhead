using GoAhead.Contracts;
using GoAhead.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Core
{
    public class DocumentsManager : IDocumentsManager
    {
        private readonly IDataProvider dataProvider;
        private readonly IDocumentsConfigProvider configProvider;

        public DocumentsManager(IDataProvider dataProvider, IDocumentsConfigProvider configProvider)
        {
            this.dataProvider = dataProvider;
            this.configProvider = configProvider;
        }

        public Document GetDocument(GetDocument documentInfo)
        {
            Configuration.DocumentsConfiguration config = this.configProvider.ReadConfiguration();
            Configuration.Document configDoc = config.Documents.FirstOrDefault(c => c.Collection == documentInfo.Collection);
            if (configDoc == null)
            {
                return null;
            }

            var result = new Document();
            result.RawJsonValue = dataProvider.GetDocument(documentInfo.Collection, documentInfo.Id);
            var document = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.RawJsonValue);

            foreach (Configuration.Reference reference in configDoc.ReferringTo)
            {
                // TODO: use enum
                if (reference.Relation == "many")
                {
                    string rawIds = document[reference.PrimaryKey].ToString();
                    foreach (string item in JsonConvert.DeserializeObject<string[]>(rawIds))
                    {
                        result.References.Add(new Reference()
                        {
                            Document = reference.PrimaryKey,
                            Id = item,
                            Collection = reference.Collection,
                        });
                    }
                }

                // TODO: use enum
                if(reference.Relation == "single")
                {
                    string id = document[reference.PrimaryKey].ToString();
                    result.References.Add(new Reference()
                    {
                        Document = reference.PrimaryKey,
                        Id = id,
                        Collection = reference.Collection
                    });
                }
            }

            return result;
        }

        public IEnumerable<Reference> GetReferences(GetReferences referencesInfo)
        {
            throw new NotImplementedException();
        }
    }
}
