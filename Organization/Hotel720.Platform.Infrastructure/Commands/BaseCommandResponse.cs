using System;

namespace Hotel720.Platform.Infrastructure.Commands
{
	public abstract class BaseCommandResponse : ICommandResponse
	{
		public Guid CommandGuid { get; set; }
		public bool Success { get; set; }
	}
}
