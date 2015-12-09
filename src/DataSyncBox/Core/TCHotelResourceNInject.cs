using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Travelling.Repository;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox.Core
{
    public class TCHotelResourceNInject : NinjectModule
    {
        public override void Load()
        {
            Bind<ITCHotelResourceBusinessLogic>().To<TCHotelResourceBusinessLogic>();
        }
    }
}
