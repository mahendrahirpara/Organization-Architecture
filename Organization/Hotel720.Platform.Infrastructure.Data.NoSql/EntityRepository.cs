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
	public class EntityRepository<T, TKey> : RepositoryBase<MongoCollection<T>>, IRepository<T, TKey> where T : IEntity<TKey>
	{

		protected EntityRepository(IDataContextFactory<MongoCollection<T>> dataContextFactory)
			: base(dataContextFactory)
		{

		}

		/// <summary>
		/// Gets the name of the collection
		/// </summary>
		public string CollectionName
		{
			get { return this.DataContext.Name; }
		}

		/// <summary>
		/// Returns the T by its given id.
		/// </summary>
		/// <param name="id">The Id of the entity to retrieve.</param>
		/// <returns>The Entity T.</returns>
		public virtual T GetById(TKey id)
		{
			if (typeof(T).IsSubclassOf(typeof(BaseEntity)))
			{
				return this.GetById(new ObjectId(id as string));
			}

			return this.DataContext.FindOneByIdAs<T>(BsonValue.Create(id));
		}

		/// <summary>
		/// Returns the T by its given id.
		/// </summary>
		/// <param name="id">The Id of the entity to retrieve.</param>
		/// <returns>The Entity T.</returns>
		public virtual T GetById(ObjectId id)
		{
			return this.DataContext.FindOneByIdAs<T>(id);
		}

		/// <summary>
		/// Adds the new entity in the repository.
		/// </summary>
		/// <param name="entity">The entity T.</param>
		/// <returns>The added entity including its new ObjectId.</returns>
		public virtual T Add(T entity)
		{
			this.DataContext.Insert<T>(entity);

			return entity;
		}

		/// <summary>
		/// Adds the new entities in the repository.
		/// </summary>
		/// <param name="entities">The entities of type T.</param>
		public virtual void Add(IEnumerable<T> entities)
		{
			this.DataContext.InsertBatch<T>(entities);
		}

		/// <summary>
		/// Upserts an entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>The updated entity.</returns>
		public virtual T Update(T entity)
		{
			this.DataContext.Save<T>(entity);

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
				this.DataContext.Save<T>(entity);
			}
		}

		/// <summary>
		/// Deletes an entity from the repository by its id.
		/// </summary>
		/// <param name="id">The entity's id.</param>
		public virtual void Delete(TKey id)
		{
			if (typeof(T).IsSubclassOf(typeof(BaseEntity)))
			{
				this.DataContext.Remove(Query.EQ("_id", new ObjectId(id as string)));
			}
			else
			{
				this.DataContext.Remove(Query.EQ("_id", BsonValue.Create(id)));
			}
		}

		/// <summary>
		/// Deletes an entity from the repository by its ObjectId.
		/// </summary>
		/// <param name="id">The ObjectId of the entity.</param>
		public virtual void Delete(ObjectId id)
		{
			this.DataContext.Remove(Query.EQ("_id", id));
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
			foreach (T entity in this.DataContext.AsQueryable<T>().Where(predicate))
			{
				this.Delete(entity.Id);
			}
		}

		/// <summary>
		/// Deletes all entities in the repository.
		/// </summary>
		public virtual void DeleteAll()
		{
			this.DataContext.RemoveAll();
		}

		/// <summary>
		/// Counts the total entities in the repository.
		/// </summary>
		/// <returns>Count of entities in the collection.</returns>
		public virtual long Count()
		{
			return this.DataContext.Count();
		}

		/// <summary>
		/// Checks if the entity exists for given predicate.
		/// </summary>
		/// <param name="predicate">The expression.</param>
		/// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
		public virtual bool Exists(Expression<Func<T, bool>> predicate)
		{
			return this.DataContext.AsQueryable<T>().Any(predicate);
		}

		#region IQueryable<T>
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator&lt;T&gt; object that can be used to iterate through the collection.</returns>
		public virtual IEnumerator<T> GetEnumerator()
		{
			return this.DataContext.AsQueryable<T>().GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.DataContext.AsQueryable<T>().GetEnumerator();
		}

		/// <summary>
		/// Gets the type of the element(s) that are returned when the expression tree associated with this instance of IQueryable is executed.
		/// </summary>
		public virtual Type ElementType
		{
			get { return this.DataContext.AsQueryable<T>().ElementType; }
		}

		/// <summary>
		/// Gets the expression tree that is associated with the instance of IQueryable.
		/// </summary>
		public virtual Expression Expression
		{
			get { return this.DataContext.AsQueryable<T>().Expression; }
		}

		/// <summary>
		/// Gets the query provider that is associated with this data source.
		/// </summary>
		public virtual IQueryProvider Provider
		{
			get { return this.DataContext.AsQueryable<T>().Provider; }
		}
		#endregion
	}

	/// <summary>
	/// Deals with entities in MongoDb.
	/// </summary>
	/// <typeparam name="T">The type contained in the repository.</typeparam>
	/// <remarks>Entities are assumed to use strings for Id's.</remarks>
	public class EntityRepository<T> : EntityRepository<T, string>, IRepository<T>
		where T : IEntity<string>
	{
		protected EntityRepository(IDataContextFactory<MongoCollection<T>> dataContextFactory)
			: base(dataContextFactory)
		{

		}
		 
	}
}