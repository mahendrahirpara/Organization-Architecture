using Hotel720.Platform.Infrastructure.Data;
using Hotel720.Platform.Infrastructure.Data.NoSql;
using MongoDB.Driver;

namespace HotelCommerce.Core.Infrastructure.Data
{
	public sealed class CoreDataContext : IDataContextFactory<IMongoDatabase>
	{
		private readonly IMongoDatabase iMongoDatabase;

		public CoreDataContext(string databaseName, string connectionString)
		{
			iMongoDatabase = MongoHelper.GetDatabase(databaseName, connectionString);
		}

		public IMongoDatabase GetContext()
		{
			return iMongoDatabase;
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}
