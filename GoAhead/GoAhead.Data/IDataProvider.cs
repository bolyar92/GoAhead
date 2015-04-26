using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Data
{
    public interface IDataProvider
    {
        string GetDocument(string collection, string documentId);
    }
}
