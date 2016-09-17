
namespace HotelCommerce.Common.Entities
{
	/// <summary>
	/// Generic Entity interface.
	/// </summary>
	/// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
	public interface IEntity
	{
		/// <summary>
		/// Gets or sets the Id of the Entity.
		/// </summary>
		/// <value>Id of the Entity.</value>
		string Id { get; set; }
	}
}
