
namespace Organization.Infrastructure.Data.Repositories
{
	using NHibernate;
	using Organization.Common.Entities;
	using Organization.Domain.Interfaces;
	using System.Linq;

	public class Repository<TEntity> : IRepository<TEntity>
	   where TEntity : BaseEntity
	{
		private readonly ISession _session;

		public Repository(ISession session)
		{
			_session = session;
		}

		#region IWriteRepository

		public bool Add(TEntity entity)
		{
			_session.Save(entity);
			return true;
		}

		public bool Add(System.Collections.Generic.IEnumerable<TEntity> entities)
		{
			foreach (TEntity entity in entities)
			{
				_session.Save(entity);
			}
			return true;
		}

		public bool Update(TEntity entity)
		{
			_session.Update(entity);
			return true;
		}

		public bool Update(System.Collections.Generic.IEnumerable<TEntity> entities)
		{
			foreach (TEntity entity in entities)
			{
				_session.Update(entity);
			}
			return true;
		}

		public bool Delete(TEntity entity)
		{
			_session.Delete(entity);
			return true;
		}

		public bool Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
		{
			foreach (TEntity entity in entities)
			{
				_session.Delete(entity);
			}
			return true;
		}

		#endregion

		#region IReadRepository

		public System.Linq.IQueryable<TEntity> All()
		{
			//return _session.QueryOver<TEntity>();
			return null;
		}

		public TEntity FindBy(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> expression)
		{
			return FilterBy(expression).SingleOrDefault();
		}

		public TEntity FindBy(object id)
		{
			return _session.Get<TEntity>(id);
		}

		public System.Linq.IQueryable<TEntity> FilterBy(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> expression)
		{
			return All().Where(expression).AsQueryable();
		}

		#endregion
	}
}
