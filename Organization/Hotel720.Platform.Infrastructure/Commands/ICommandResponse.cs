using System;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface ICommandResponse
    {
        Guid CommandGuid { get; set; }

		bool Success { get; }
    }
}
