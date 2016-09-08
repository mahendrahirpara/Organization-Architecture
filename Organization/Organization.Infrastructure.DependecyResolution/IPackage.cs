
namespace Organization.Infrastructure.DependecyResolution
{
	public interface IPackage
	{
		void RegisterServices(SimpleInjector.Container container);
	}
}
