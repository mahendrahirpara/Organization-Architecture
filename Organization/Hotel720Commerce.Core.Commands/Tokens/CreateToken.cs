
namespace HotelCommerce.Core.Commands.Tokens
{
	using Hotel720.Platform.Infrastructure.Commands;
	using System;

	public sealed class CreateToken : BaseCommand
	{
		public string Username { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? ExpiryDate { get; set; }
	}
}
