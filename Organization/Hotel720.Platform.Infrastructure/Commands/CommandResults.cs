﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Commands
{
    public class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> results = new List<ICommandResult>();

        public void AddResult(ICommandResult result)
        {
            this.results.Add(result);
        }

        public ICommandResult[] Results
        {
            get
            {
                return this.results.ToArray();
            }
        }

        public bool Success
        {
            get
            {
                return this.results.All<ICommandResult>(result => result.Success);
            }
        }
    }
}
