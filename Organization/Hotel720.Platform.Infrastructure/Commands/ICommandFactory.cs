namespace Hotel720.Platform.Infrastructure.Commands
{
	public interface ICommandFactory
	{
		T Get<T>() where T : BaseCommand;
	}
}
