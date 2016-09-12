using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel720.Platform.Infrastructure.Commands
{
	public abstract class BaseCommandResponses : ICommandResponses
	{
		private readonly List<ICommandResponse> results = new List<ICommandResponse>();

		public void AddResult(ICommandResponse result)
		{
			this.results.Add(result);
		}

		public ICommandResponse[] Results
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
				return this.results.All<ICommandResponse>(result => result.Success);
			}
		}
	}
}
