
namespace Organization.Infrastructure.Data.Helpers
{
	using FluentNHibernate.Cfg;
	using NHibernate;
	using NHibernate.Cfg;

	public class NHibernateHelper
	{
		private ISessionFactory _sessionFactory;
		private readonly string _connectionString;

		public NHibernateHelper(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new HibernateConfigException("ConnectionString in Web.config is not set.");

			_connectionString = connectionString;
		}

		public ISessionFactory SessionFactory
		{
			get
			{
				return _sessionFactory ?? (_sessionFactory = InitializeSessionFactory());
			}
		}

		private ISessionFactory InitializeSessionFactory()
        {
			return null;
        }
	}

}
