namespace Hotel720.Platform.Infrastructure.Data
{
	using HotelCommerce.Common.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// IRepository definition.
	/// </summary>
	/// <typeparam name="T">The type contained in the repository.</typeparam>
	/// <typeparam name="TKey">The type used for the entity's Id.</typeparam>
	public interface IRepository<T> : IQueryable<T>
		where T : IEntity
	{
		/// <summary>
		/// Gets the Mongo collection (to perform advanced operations).
		/// </summary>
		/// <remarks>
		/// One can argue that exposing this property (and with that, access to it's Database property for instance
		/// (which is a "parent")) is not the responsibility of this class. Use of this property is highly discouraged;
		/// for most purposes you can use the MongoRepositoryManager&lt;T&gt;
		/// </remarks>
		/// <value>The Mongo collection (to perform advanced operations).</value>
		//MongoCollection<T> Collection { get; }

		/// <summary>
		/// Returns the T by its given id.
		/// </summary>
		/// <param name="id">The value representing the ObjectId of the entity to retrieve.</param>
		/// <returns>The Entity T.</returns>
		T GetById(object id);

		/// <summary>
		/// Adds the new entity in the repository.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		/// <returns>The added entity including its new ObjectId.</returns>
		T Add(T entity);

		/// <summary>
		/// Adds the new entities in the repository.
		/// </summary>
		/// <param name="entities">The entities of type T.</param>
		void Add(IEnumerable<T> entities);

		/// <summary>
		/// Upserts an entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>The updated entity.</returns>
		T Update(T entity);

		/// <summary>
		/// Upserts the entities.
		/// </summary>
		/// <param name="entities">The entities to update.</param>
		void Update(IEnumerable<T> entities);

		/// <summary>
		/// Deletes an entity from the repository by its id.
		/// </summary>
		/// <param name="id">The entity's id.</param>
		void Delete(object id);

		/// <summary>
		/// Deletes the given entity.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void Delete(T entity);

		/// <summary>
		/// Checks if the entity exists for given predicate.
		/// </summary>
		/// <param name="predicate">The expression.</param>
		/// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
		bool Exists(Expression<Func<T, bool>> predicate);
	}

}