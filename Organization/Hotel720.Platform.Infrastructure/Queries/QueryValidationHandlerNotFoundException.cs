using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Queries
{
    public class QueryValidationHandlerNotFoundException : Exception
    {
        public QueryValidationHandlerNotFoundException(Type type)
            : base(string.Format("Query validation handler not found for query type: {0}", type))
        {
        }
    }
}
