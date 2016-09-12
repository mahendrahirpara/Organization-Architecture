using Hotel720.Platform.Infrastructure.Commands;
using SimpleInjector;

namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Commands
{
    public class CommandFactory : ICommandFactory
    {
		private readonly Container container;
		public CommandFactory(Container container)
        {
			this.container = container;
        }

        public T Get<T>(string name= null) where T : ICommand
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
				//return this.container.GetInstance<T>(name);
            }
			return this.container.GetInstance<T>();
        }
    }
}
