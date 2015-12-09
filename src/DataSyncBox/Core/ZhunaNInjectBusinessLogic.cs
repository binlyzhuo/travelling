using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Travelling.TravelInterface.Repository;
using Travelling.Repository;

namespace DataSyncBox.Core
{
    public class ZhunaNInjectBusinessLogic : NinjectModule
    {
        public override void Load()
        {
            Bind<IZhunaHotelBusinessLogic>().To<ZhunaHotelBusinessLogic>();
            Bind<IZhunaHotelSyncBusinessLogic>().To<ZhunaHotelSyncBusinessLogic>();
        }
    }
}
