

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Packages
{
	using Hotel720.Platform.Infrastructure;
	using Hotel720.Platform.Infrastructure.Data;
	using HotelCommerce.Core.Infrastructure.DependecyResolution.Data;

	public sealed class RepositoryInfrastructurePackage : IPackage<SimpleInjector.Container>
	{
		public void RegisterServices(SimpleInjector.Container container)
		{
			container.RegisterSingleton<IRepositoryFactory, RepositoryFactory>();
			container.RegisterSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
		}
	}
}
