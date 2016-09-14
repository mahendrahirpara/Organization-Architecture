using Hotel720.Platform.Infrastructure.Data;
using MongoDB.Driver;

namespace HotelCommerce.Core.Infrastructure.Data
{
	public sealed class CoreDataContext<T> : IDataContextFactory<IMongoCollection<T>>
	{
		private static readonly IMongoDatabase iMongoDatabase;

		static CoreDataContext()
		{
			//iMongoDatabase =  MongoDbConnection<
		}

		public IMongoCollection<T> GetContext()
		{
			return iMongoDatabase.GetCollection<T>("");
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}
