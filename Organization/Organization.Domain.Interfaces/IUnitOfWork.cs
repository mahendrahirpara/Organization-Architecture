using System;

namespace Organization.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();

		void Rollback();
	}
}
