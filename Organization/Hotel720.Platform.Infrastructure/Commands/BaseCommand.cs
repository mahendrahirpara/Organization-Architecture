using System;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public abstract class BaseCommand : ICommand
    { 
        public Guid Id { get; set; }
    }
}
