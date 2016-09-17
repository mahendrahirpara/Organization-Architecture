namespace Hotel720.Platform.Infrastructure.Data.NoSql
{
	using HotelCommerce.Common.Entities;
	using MongoDB.Driver;
	using System;

	/// <summary>
	/// Internal miscellaneous utility functions.
	/// </summary>
	public static class MongoHelper
	{
		/// <summary>
		/// Creates and returns a MongoDatabase from the specified url.
		/// </summary>
		/// <param name="url">The url to use to get the database from.</param>
		/// <returns>Returns a MongoDatabase from the specified url.</returns>
		public static IMongoDatabase GetDatabase(string databaseName, string connectionString)
		{
			MongoClient mongoClient = new MongoClient(connectionString);
			return mongoClient.GetDatabase(databaseName);
		}

		/// <summary>
		/// Determines the collectionname for T and assures it is not empty
		/// </summary>
		/// <typeparam name="T">The type to determine the collectionname for.</typeparam>
		/// <returns>Returns the collectionname for T.</returns>
		public static string GetCollectionName<T>() where T : IEntity
		{
			string collectionName;
			if (typeof(T).BaseType.Equals(typeof(object)))
			{
				collectionName = GetCollectioNameFromInterface<T>();
			}
			else
			{
				collectionName = GetCollectionNameFromType(typeof(T));
			}

			if (string.IsNullOrEmpty(collectionName))
			{
				throw new ArgumentException("Collection name cannot be empty for this entity");
			}
			return collectionName;
		}

		/// <summary>
		/// Determines the collectionname from the specified type.
		/// </summary>
		/// <typeparam name="T">The type to get the collectionname from.</typeparam>
		/// <returns>Returns the collectionname from the specified type.</returns>
		private static string GetCollectioNameFromInterface<T>()
		{
			string collectionname;

			// Check to see if the object (inherited from Entity) has a CollectionName attribute
			var att = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionNameAttribute));
			if (att != null)
			{
				// It does! Return the value specified by the CollectionName attribute
				collectionname = ((CollectionNameAttribute)att).Name;
			}
			else
			{
				collectionname = typeof(T).Name;
			}

			return collectionname;
		}

		/// <summary>
		/// Determines the collectionname from the specified type.
		/// </summary>
		/// <param name="entitytype">The type of the entity to get the collectionname from.</param>
		/// <returns>Returns the collectionname from the specified type.</returns>
		private static string GetCollectionNameFromType(Type entitytype)
		{
			string collectionname;

			// Check to see if the object (inherited from Entity) has a CollectionName attribute
			var att = Attribute.GetCustomAttribute(entitytype, typeof(CollectionNameAttribute));
			if (att != null)
			{
				// It does! Return the value specified by the CollectionName attribute
				collectionname = ((CollectionNameAttribute)att).Name;
			}
			else
			{
				if (typeof(BaseEntity).IsAssignableFrom(entitytype))
				{
					// No attribute found, get the basetype
					while (!entitytype.BaseType.Equals(typeof(BaseEntity)))
					{
						entitytype = entitytype.BaseType;
					}
				}
				collectionname = entitytype.Name;
			}

			return collectionname;
		}
	}
}

