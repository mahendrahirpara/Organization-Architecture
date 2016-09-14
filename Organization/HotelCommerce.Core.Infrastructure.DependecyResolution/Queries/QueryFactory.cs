
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Queries
{
	using Hotel720.Platform.Infrastructure.Queries;
	using SimpleInjector;

    public sealed class QueryFactory : IQueryFactory
    {
		private readonly Container container;
        public QueryFactory(Container container)
        {
			this.container = container;
        }

        public T Get<T>() where T : class
        {
			return container.GetInstance<T>();
        }
    }
}
