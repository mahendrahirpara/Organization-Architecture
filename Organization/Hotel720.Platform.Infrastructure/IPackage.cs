
namespace Hotel720.Platform.Infrastructure
{
	public interface IPackage<T>
	{
		void RegisterServices(T container);
	}
}
