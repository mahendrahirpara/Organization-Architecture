
using System;
namespace Hotel720.Platform.Infrastructure.Commands
{
	public interface ICommand
	{
		Guid Id { get; set; }
	}
}
