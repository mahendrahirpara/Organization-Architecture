

namespace HotelCommerce.Core.Domain.Entities.Tokens
{
	using HotelCommerce.Common.Entities;
	using System;

	public sealed class Token  : BaseEntity
	{
		public Guid Ticket { get; set; }

		public string Username { get; set; }

		public DateTime SessionStartTime { get; set; }

		public DateTime LastActivityTime { get; set; }

		public DateTime? SessionExpiredTime { get; set; }
	}
}
