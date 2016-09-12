using Hotel720.Platform.Infrastructure.Queries;
using SimpleInjector;

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Queries
{
    public class QueryFactory : IQueryFactory
    {
		private readonly Container container;
        public QueryFactory(Container container)
        {
			this.container = container;
        }

        public T Get<T>(string name = null) where T : IQuery
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
				///return container.GetInstance<T>(name);
            }
			return container.GetInstance<T>();
        }
    }
}
