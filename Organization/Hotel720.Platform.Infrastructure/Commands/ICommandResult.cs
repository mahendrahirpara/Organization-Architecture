using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        Guid Guid { get; }
        Guid[] Guids { get; }
        int Id { get; }
    }
}
