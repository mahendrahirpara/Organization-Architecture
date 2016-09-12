
namespace HotelCommerce.Core.Infrastructure.DependecyResolution.Packages
{
    public class CQRSModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandBus>().To<CommandBus>().InTransientScope();
            Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            Bind<IQueryBus>().To<QueryBus>().InTransientScope();
            Bind<IQueryFactory>().To<QueryFactory>().InSingletonScope();
        }
    }
}
