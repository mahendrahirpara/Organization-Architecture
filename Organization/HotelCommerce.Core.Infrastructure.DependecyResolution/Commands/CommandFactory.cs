
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Commands
{
	using Hotel720.Platform.Infrastructure.Commands;
	using SimpleInjector;

	public sealed class CommandFactory : ICommandFactory
	{
		private readonly Container container;

		public CommandFactory(Container container)
		{
			this.container = container;
		} 

		public T Get<T>() where T : BaseCommand
		{
			return this.container.GetInstance<T>();
		}
	}
}
