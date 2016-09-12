namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface ICommandFactory
    {
        T Get<T>(string name = null) where T:ICommand;
    }
}
