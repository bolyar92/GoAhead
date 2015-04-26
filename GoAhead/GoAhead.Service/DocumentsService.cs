using GoAhead.Contracts;
using GoAhead.Core;
using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStack.FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Service
{
    public class DocumentsService : ServiceStack.Service
    {
        // TODO: add validation
        // TODO: add loging
        // TOOD: add error handling

        private readonly IDocumentsManager documentsManager;
        private readonly IDocumentsConfigProvider documentsConfigProvider;

        public DocumentsService(IDocumentsManager documentsManager, IDocumentsConfigProvider documentsConfigProvider)
        {
            this.documentsManager = documentsManager;
            this.documentsConfigProvider = documentsConfigProvider;
        }

        public Document Get(GetDocumentRequest request)
        {
            return this.documentsManager.GetDocument(request);
        }

        public List<Reference> Get(GetReferencesRequest request)
        {
            return this.documentsManager.GetReferences(request).ToList();
        }

        public string[] Get(GetCollectionsRequest request)
        {
            return this.documentsConfigProvider
                .ReadConfiguration()
                .Documents
                .Select(d => d.Collection)
                .ToArray();
        }
    }
}
