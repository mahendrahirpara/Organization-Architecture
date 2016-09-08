
namespace Organization.Infrastructure.DependecyResolution
{
	public class RepositoryPackage : IPackage
	{
		#region IPackage implementation

		public void RegisterServices(SimpleInjector.Container container)
		{

			//container.RegisterPerWebRequest<ISessionFactory>(() =>
			//{

			//	var configPackage = container.GetInstance<IConfigService>();
			//	NHibernateHelper objNHibernate = new NHibernateHelper(configPackage.Connection);
			//	return objNHibernate.SessionFactory;
			//});

			//container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();

			//container.RegisterPerWebRequest<ISession>(() =>
			//{

			//	UnitOfWork unitOfWork = (UnitOfWork)container.GetInstance<IUnitOfWork>();
			//	return unitOfWork.Session;

			//});

			//container.RegisterOpenGeneric(typeof(IReadWriteRepository<>), typeof(Repository<>));
		}

		#endregion
	}
}
