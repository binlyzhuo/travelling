using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Repository;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox.Core
{
    public class TicketInjectDataProvider : NinjectModule
    {
        public override void Load()
        {
            //throw new NotImplementedException();
            Bind<ISceneryTicketInfoBusinessLogic>().To<SceneryTicketInfoBusinessLogic>();
            Bind<ISceneryTicketDataSyncBusinessLogic>().To<SceneryTicketDataSyncBusinessLogic>();
        }
    }
}
