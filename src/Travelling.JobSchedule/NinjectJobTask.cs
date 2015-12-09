using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Repository;
using Travelling.TravelInterface.Repository;

namespace Travelling.JobSchedule
{
    public class NinjectJobTask : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IJobScheduleBusinessLogic>().To<JobScheduleBusinessLogic>();
            Bind<IHotelDataSyncBusinssLogic>().To<HotelDataSyncBusinssLogic>();
            Bind<IHotelInfoBusinessLogic>().To<HotelInfoBusinessLogic>();
        }
    }
}
