using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success)
        {
            this.Success = success;
        }

        public CommandResult(bool success, Guid Guid)
        {
            this.Success = success;
            this.Guids = new Guid[] { Guid };
        }

        public CommandResult(bool success, int Id)
        {
            this.Success = success;
            this.Id = Id;
        }

        public CommandResult(bool success, Guid[] Guids)
        {
            this.Success = success;
            this.Guids = Guids;
        }

        public bool Success { get; protected set; }

        public Guid Guid { get { return Guids[0]; } }

        public Guid[] Guids { get; set; }

        public int Id { get; protected set; }
    }
}
