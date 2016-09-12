using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Data
{
	public interface IDataContextFactory<out TContext> : IDisposable 
	{
		TContext GetContext();
	}
}
