using Hotel720.Platform.Infrastructure.Data;
using Hotel720.Platform.Infrastructure.Data.NoSql;
using MongoDB.Driver;

namespace HotelCommerce.Core.Infrastructure.Data
{
	public sealed class TokensDataContext : IDataContextFactory<IMongoDatabase>
	{
		private readonly IMongoDatabase iMongoDatabase;

		public TokensDataContext(string databaseName, string connectionString)
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
