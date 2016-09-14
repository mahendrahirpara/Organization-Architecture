namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Queries
{
	using Hotel720.Platform.Infrastructure.Queries;
	using SimpleInjector;

    public sealed class QueryBus : IQueryBus
    {
		private readonly Container container;

		public QueryBus(Container container)
        {
			this.container = container;
        }

        public IView Send<T>(T query) where T : IQuery
        {
			var queryHandler = container.GetInstance<IQueryHandler<T>>();
            return queryHandler.Query(query);
        }
    }
}
