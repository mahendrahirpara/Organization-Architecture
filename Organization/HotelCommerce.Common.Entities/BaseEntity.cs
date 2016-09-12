namespace HotelCommerce.Common.Entities
{
	using System;

	/// <summary>
	/// Base class for entities
	/// </summary>
	public abstract class BaseEntity : IEntity
	{
		public string Id { get; set; }

		public bool IsActive { get; set; }

		public bool IsDeleted { get; set; }

	}
}
