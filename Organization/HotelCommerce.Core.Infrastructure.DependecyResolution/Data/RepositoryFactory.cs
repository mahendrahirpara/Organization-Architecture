
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Data
{
	using Hotel720.Platform.Infrastructure.Data;
	using HotelCommerce.Common.Entities;
	using SimpleInjector;

    public sealed class RepositoryFactory : IRepositoryFactory
    {
		private readonly Container container;
		public RepositoryFactory(Container container)
        {
			this.container = container;
        }

		public IRepository<T> Get<T>() where T : IEntity
        {
			return container.GetInstance<IRepository<T>>();
        }
    }
}
