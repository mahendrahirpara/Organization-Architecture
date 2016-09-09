using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Queries
{
    public interface IValidationQueryHandler<in TQuery> where TQuery : IQuery
    {
        IEnumerable<ValidationResult> Validate(TQuery query, string strToken, string strSwitchAccountId, bool bSkipTokenValidation);
        //IEnumerable<ValidationResult> Validate(TQuery[] queries, string strToken, bool bSkipTokenValidation);
    }
}
