
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Packages
{
    public class RepositoryInfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().To<RepositoryFactory>().InSingletonScope();
            Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>().InSingletonScope();
        }
    }
}
