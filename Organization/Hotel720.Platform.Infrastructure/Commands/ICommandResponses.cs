﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public interface ICommandResponses
    {
		ICommandResponse[] Results { get; }

        bool Success { get; }
    }
}
