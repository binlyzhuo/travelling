using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Repository;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox
{
    public class DependencyResolver : NinjectModule
    {
        public override void Load()
        {
            
            
            // bind ninject
            Bind<IHotelDataSyncBusinssLogic>().To<HotelDataSyncBusinssLogic>();
            Bind<ISceneryTicketInfoBusinessLogic>().To<SceneryTicketInfoBusinessLogic>();

            Bind<IHotelLuceneIndexBusinessLogic>().To<HotelLuceneIndexBusinessLogic>();
            Bind<IHotelCityBusinessLogic>().To<HotelCityBusinessLogic>();
            Bind<IHotelInfoBusinessLogic>().To<HotelInfoBusinessLogic>();
            Bind<ISystemLogBusinessLogic>().To<SystemLogBusinessLogic>();
            Bind<IAccountBusinessLogic>().To<AccountBusinessLogic>();
        }
    }
}
