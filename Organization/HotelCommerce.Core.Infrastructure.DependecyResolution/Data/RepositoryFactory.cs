using Hotel720.Platform.Infrastructure.Data;
using SimpleInjector;

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
		private readonly Container container;
		public RepositoryFactory(Container container)
        {
			this.container = container;
        }

        public IRepository<T> Get<T>(string name = null) where T : class
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
				//return container.GetInstance<IRepository<T>>(name);
            }
			return container.GetInstance<IRepository<T>>();
        }
    }
}
