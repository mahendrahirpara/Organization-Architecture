namespace Hotel720.Platform.Infrastructure.Queries
{
    public interface IQueryFactory
    {
        T Get<T>(string name = null) where T : IQuery;
    }
}
