
namespace HotelCommerce.Common.Entities
{
	using System;

	public abstract class AuditableEntity : BaseEntity
	{
		public int CommandID { get; set; }

		public int CreateBy { get; set; }

		public DateTime CreateDateTime { get; set; }

		public int UpdateBy { get; set; }

		public DateTime UpdateDateTime { get; set; }

		public int DeleteBy { get; set; }

		public DateTime DeleteDateTime { get; set; }
	}
}
