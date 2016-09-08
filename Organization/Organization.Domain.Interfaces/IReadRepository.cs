

namespace Organization.Domain.Interfaces
{
	using Organization.Common.Entities;
	using System;
	using System.Linq;
	using System.Linq.Expressions;

	public interface IReadRepository<TEntity> where TEntity : BaseEntity
	{
		IQueryable<TEntity> All();

		TEntity FindBy(Expression<Func<TEntity, bool>> expression);

		TEntity FindBy(object id);

		IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
	}
}
