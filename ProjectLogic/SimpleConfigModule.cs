using DataAccessLayer;
using ModelLogic1;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectLogic
{
    public class SimpleConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Player>>().To<EntityRepository<Player>>().InSingletonScope();
            Bind<IPlayerOperations>().To<PlayerWorkOperations>().InSingletonScope();
            Bind<DbContext>().ToSelf().InSingletonScope();
            Bind<IPositionOperations>().To<PositionWorkOperations>().InSingletonScope();
            Bind<ILogic>().To<Logic>().InSingletonScope();
        }
    }
}
