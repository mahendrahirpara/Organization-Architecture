using Hotel720.Platform.Infrastructure;
using Hotel720.Platform.Infrastructure.Data;
using HotelCommerce.Core.Infrastructure.Data;
using MongoDB.Driver;

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Packages
{
	public sealed class CoreDataContextPackage : IPackage<SimpleInjector.Container>
	{
		public void RegisterServices(SimpleInjector.Container container)
		{
			container.RegisterSingleton<IDataContextFactory<IMongoDatabase>, CoreDataContext>();
			//container.RegisterSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
		}
	}
}
