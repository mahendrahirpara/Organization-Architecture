

namespace Organization.Domain.Interfaces
{
	using Organization.Common.Entities;
	using System.Collections.Generic;

	public interface IWriteRepository<TEntity> where TEntity : BaseEntity
	{
		bool Add(TEntity entity);

		bool Add(IEnumerable<TEntity> entities);

		bool Update(TEntity entity);

		bool Update(IEnumerable<TEntity> entities);

		bool Delete(TEntity entity);

		bool Delete(IEnumerable<TEntity> entities);
	}
}
