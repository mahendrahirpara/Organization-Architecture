

namespace Hotel720.Platform.Infrastructure.Data
{
	using HotelCommerce.Common.Entities;

	public interface IRepositoryFactory
	{
		IRepository<T> Get<T>(string named = null) where T : IEntity;
	}
}
