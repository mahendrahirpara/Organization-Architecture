using System;

namespace Organization.Domain.Entities.Restaurants
{
	public class Restaurant
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

		public bool IsActive { get; set; }

		public bool IsDeleted { get; set; }

		public int CommandID { get; set; }

		public int CreateBy { get; set; }

		public DateTime CreateDateTime { get; set; }

		public int UpdateBy { get; set; }

		public DateTime UpdateDateTime { get; set; }

		public int DeleteBy { get; set; }

		public DateTime DeleteDateTime { get; set; }

	}
}
