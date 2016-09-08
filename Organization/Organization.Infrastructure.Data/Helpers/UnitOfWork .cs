

namespace Organization.Infrastructure.Data.Helpers
{
	using NHibernate;
	using Organization.Domain.Interfaces;
	using System;
	using System.Data;
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ISessionFactory _sessionFactory;
		private readonly ITransaction _transaction;

		public ISession Session { get; private set; }

		public UnitOfWork(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
			Session = _sessionFactory.OpenSession();
			Session.FlushMode = FlushMode.Auto;
			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Commit()
		{
			if (!_transaction.IsActive)
			{
				throw new InvalidOperationException("Oops! We don't have an active transaction");
			}
			_transaction.Commit();
		}

		public void Rollback()
		{
			if (_transaction.IsActive)
			{
				_transaction.Rollback();
			}
		}

		public void Dispose()
		{
			if (Session.IsOpen)
			{
				Session.Close();
				Session = null;
			}
		}
	}
}
