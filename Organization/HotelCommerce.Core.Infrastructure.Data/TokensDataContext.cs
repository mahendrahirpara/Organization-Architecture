using Hotel720.Platform.Infrastructure.Data;
using MongoDB.Driver;

namespace HotelCommerce.Core.Infrastructure.Data
{
	public sealed class TokensDataContext<T> : IDataContextFactory<IMongoCollection<T>>
	{

		public IMongoCollection<T> GetContext()
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}
