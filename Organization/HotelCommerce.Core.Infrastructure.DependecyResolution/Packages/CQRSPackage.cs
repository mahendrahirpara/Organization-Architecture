

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Packages
{
	using Hotel720.Platform.Infrastructure;
	using Hotel720.Platform.Infrastructure.Commands;
	using Hotel720.Platform.Infrastructure.Queries;
	using HotelCommerce.Core.Infrastructure.DependecyResolution.Commands;
	using HotelCommerce.Core.Infrastructure.DependecyResolution.Queries;

	public sealed class CQRSPackage : IPackage<SimpleInjector.Container>
    {
		public void RegisterServices(SimpleInjector.Container container)
		{
			container.Register<ICommandBus, CommandBus>();
			container.RegisterSingleton<ICommandFactory, CommandFactory>();
			container.Register<IQueryBus, QueryBus>();
			container.RegisterSingleton<IQueryFactory, QueryFactory>();
		}
    }
}
