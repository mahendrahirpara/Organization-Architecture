namespace Hotel720.Platform.Infrastructure.Data.NoSql
{
	using HotelCommerce.Common.Entities;
	using MongoDB.Bson;
	using MongoDB.Driver;
	using MongoDB.Driver.Builders;
	using MongoDB.Driver.Linq;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// Deals with entities in MongoDb.
	/// </summary>
	/// <typeparam name="T">The type contained in the repository.</typeparam>
	/// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
	public class EntityRepository<T> : RepositoryBase<IMongoDatabase>, IRepository<T> where T : IEntity
	{
		private readonly IMongoCollection<T> DataCollection;

		private static readonly string DataContextName = MongoHelper.GetCollectionName<T>();

		protected EntityRepository(IDataContextFactory<IMongoDatabase> dataContextFactory)
			: base(dataContextFactory)
		{
			this.DataCollection = this.DataContext.GetCollection<T>(DataContextName);
		}

		/// <summary>
		/// Returns the T by its given id.
		/// </summary>
		/// <param name="id">The Id of the entity to retrieve.</param>
		/// <returns>The Entity T.</returns>
		public virtual T GetById(object id)
		{
			return this.DataCollection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result;

		}

		/// <summary>
		/// Adds the new entity in the repository.
		/// </summary>
		/// <param name="entity">The entity T.</param>
		/// <returns>The added entity including its new ObjectId.</returns>
		public virtual T Add(T entity)
		{
			this.DataCollection.InsertOne(entity);
			return entity;
		}

		/// <summary>
		/// Adds the new entities in the repository.
		/// </summary>
		/// <param name="entities">The entities of type T.</param>
		public virtual void Add(IEnumerable<T> entities)
		{
			this.DataCollection.InsertMany(entities);
		}

		/// <summary>
		/// Upserts an entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>The updated entity.</returns>
		public virtual T Update(T entity)
		{
			this.DataCollection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
			{
				IsUpsert = true
			});

			return entity;

		}

		/// <summary>
		/// Upserts the entities.
		/// </summary>
		/// <param name="entities">The entities to update.</param>
		public virtual void Update(IEnumerable<T> entities)
		{
			foreach (T entity in entities)
			{
				this.DataCollection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
				{
					IsUpsert = true
				});
			}
		}

		/// <summary>
		/// Deletes an entity from the repository by its id.
		/// </summary>
		/// <param name="id">The entity's id.</param>
		public virtual void Delete(object id)
		{
			this.DataCollection.DeleteOneAsync(x => x.Id.Equals(id));
		}

		/// <summary>
		/// Deletes the given entity.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		public virtual void Delete(T entity)
		{
			this.Delete(entity.Id);
		}

		/// <summary>
		/// Deletes the entities matching the predicate.
		/// </summary>
		/// <param name="predicate">The expression.</param>
		public virtual void Delete(Expression<Func<T, bool>> predicate)
		{
			this.DataCollection.DeleteMany(predicate);
		}

		/// <summary>
		/// Checks if the entity exists for given predicate.
		/// </summary>
		/// <param name="predicate">The expression.</param>
		/// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
		public virtual bool Exists(Expression<Func<T, bool>> predicate)
		{
			return this.DataCollection.AsQueryable<T>().Any(predicate);
		}

		#region IQueryable<T>
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator&lt;T&gt; object that can be used to iterate through the collection.</returns>
		public virtual IEnumerator<T> GetEnumerator()
		{
			return this.DataCollection.AsQueryable<T>().GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.DataCollection.AsQueryable<T>().GetEnumerator();
		}

		/// <summary>
		/// Gets the type of the element(s) that are returned when the expression tree associated with this instance of IQueryable is executed.
		/// </summary>
		public virtual Type ElementType
		{
			get { return this.DataCollection.AsQueryable<T>().ElementType; }
		}

		/// <summary>
		/// Gets the expression tree that is associated with the instance of IQueryable.
		/// </summary>
		public virtual Expression Expression
		{
			get { return this.DataCollection.AsQueryable<T>().Expression; }
		}

		/// <summary>
		/// Gets the query provider that is associated with this data source.
		/// </summary>
		public virtual IQueryProvider Provider
		{
			get { return this.DataCollection.AsQueryable<T>().Provider; }
		}
		#endregion
	}
}