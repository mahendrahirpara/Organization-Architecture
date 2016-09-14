namespace Hotel720.Platform.Infrastructure.Queries
{
    public interface IQueryFactory
    {
        T Get<T>() where T : class;
    }
}
