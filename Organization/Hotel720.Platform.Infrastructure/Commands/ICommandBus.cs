namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface ICommandBus
    {
        ICommandResponse Send<T>(T command) where T : ICommand;
    }
}
