using System;
using System.Collections.Generic;

namespace Hotel720.Platform.Infrastructure.Queries
{
	public interface IQueryHandler<T> where T : IQuery
	{
		IView Query(T query);
	}
}
