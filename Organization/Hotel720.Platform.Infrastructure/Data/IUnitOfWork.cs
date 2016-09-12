using System;

namespace Hotel720.Platform.Infrastructure.Data
{
	public interface IUnitOfWork : IDisposable
	{
		void BeginTransaction();

		void Commit();

		void Rollback();
	}
}
