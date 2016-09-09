using System;
using System.Collections.Generic;

namespace Hotel720.Platform.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery>
        where TQuery : IQuery
    {
        IQueryResult Execute(TQuery query);
        //IQueryResult Execute(TQuery[] queries);
    }
}
