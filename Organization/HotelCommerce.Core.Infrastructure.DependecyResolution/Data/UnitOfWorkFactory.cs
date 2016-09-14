
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Data
{
	using Hotel720.Platform.Infrastructure.Data;
	using SimpleInjector;

    public sealed class UnitOfWorkFactory : IUnitOfWorkFactory
    {
		private readonly Container container;
		public UnitOfWorkFactory(Container container)
        {
			this.container = container;
        }

        public IUnitOfWork Get()
        {
			return container.GetInstance<IUnitOfWork>();
        }
    }
}
