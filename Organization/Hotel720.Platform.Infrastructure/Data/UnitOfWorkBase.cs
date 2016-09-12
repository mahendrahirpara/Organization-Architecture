

namespace Hotel720.Platform.Infrastructure.Data
{
	using System;

	public abstract class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : class, IDisposable
	{
		private readonly IDataContextFactory<TContext> _dataContextFactory;

		private TContext _dataContext;

		protected UnitOfWorkBase(IDataContextFactory<TContext> dataContextFactory)
		{
			_dataContextFactory = dataContextFactory;
		}

		protected TContext DataContext
		{
			get
			{
				_dataContext = _dataContextFactory.GetContext();
				{
					return _dataContext;
				}
			}
		}

		public abstract void BeginTransaction();

		public abstract void Commit();

		public abstract void Rollback();

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					if (_dataContext != null)
					{
						_dataContext.Dispose();
					}
					_dataContext = null;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~UnitOfWorkBase() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
