using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
	public interface ICommandHandler<in T> where T : ICommand
	{
		ICommandResponse Execute(T command);

		//ICommandResponses Execute(T[] commands);
	}
}
