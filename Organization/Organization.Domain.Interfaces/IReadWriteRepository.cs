
namespace Organization.Domain.Interfaces
{
	using Organization.Common.Entities;

	public interface IRepository<TEntity> :
					   IReadRepository<TEntity>, IWriteRepository<TEntity> where TEntity : BaseEntity
	{

	}
}
