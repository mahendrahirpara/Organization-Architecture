
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Commands
{
	using Hotel720.Platform.Infrastructure.Commands;
	using SimpleInjector;

    public class CommandBus : ICommandBus
    {
		private readonly Container container;
		public CommandBus(Container container)
        {
			this.container = container;
        }
		
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="command"></param>
		/// <returns></returns>
        public ICommandResponse Send<T>(T command) where T : ICommand
        {
			var commandHandler = container.GetInstance<ICommandHandler<T>>();
            return commandHandler.Execute(command);
        }
    }
}
