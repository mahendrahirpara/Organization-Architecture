using Hotel720.Platform.Infrastructure.Data;
using SimpleInjector;

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
		private readonly Container container;
		public UnitOfWorkFactory(Container container)
        {
			this.container = container;
        }
        public IUnitOfWork Get(string named = null)
        {
            if (!string.IsNullOrWhiteSpace(named))
            {
				//return container.Get<IUnitOfWork>(named);
            }
			return container.GetInstance<IUnitOfWork>();
        }
    }
}
