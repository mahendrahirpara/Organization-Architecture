

namespace Organization.Domain.Restaurants
{
	using Organization.Common.Entities;

	public sealed class Restaurant : BaseEntity
	{
		public int RestaurantID { get; set; }

		public string RestaurantName { get; set; }

		public string OwnerName { get; set; }

		public string RestaurantAddress { get; set; }

		public string WebsiteURL { get; set; }

		public string EmailID { get; set; }

		public string Phone { get; set; }

		public string VATTINNo { get; set; }

		public string CSTTINNo { get; set; }


	}
}
