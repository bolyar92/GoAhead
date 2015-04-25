using GoAhead.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Data
{
    public interface IDocumentsManager
    {
        Document GetDocument(GetDocument documentInfo);
        IEnumerable<Reference> GetReferences(GetReferences referencesInfo);
    }
}
