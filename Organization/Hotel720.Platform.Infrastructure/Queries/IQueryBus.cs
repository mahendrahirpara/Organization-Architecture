namespace Hotel720.Platform.Infrastructure.Queries
{
    public interface IQueryBus
    {
        IView Send<T>(T query) where T : IQuery;
    }
}
