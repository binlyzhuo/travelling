using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ninject;
using Travelling.Repository;
using Travelling.TravelInterface;
using Travelling.TravelInterface.Repository;

namespace Travelling.Web
{
    /// <summary>
    /// Mvc依赖注入相关
    /// </summary>
    public class NInjectControllerFactory : IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NInjectControllerFactory()
        {
            this.kernel = new StandardKernel();
            this.Binding();
        }

        /// <summary>
        /// 绑定接口和实现
        /// </summary>
        private void Binding()
        {
            
            //
            this.kernel.Bind<IHotelInfoBusinessLogic>().To<HotelInfoBusinessLogic>();
            this.kernel.Bind<ISceneryTicketInfoBusinessLogic>().To<SceneryTicketInfoBusinessLogic>();
            this.kernel.Bind<IHotelManageBusinessLogic>().To<HotelManageBusinessLogic>();
            this.kernel.Bind<IJobScheduleBusinessLogic>().To<JobScheduleBusinessLogic>();
            this.kernel.Bind<ITicketManageBusinessLogic>().To<TicketManageBusinessLogic>();
            this.kernel.Bind<IAccountBusinessLogic>().To<AccountBusinessLogic>();
            this.kernel.Bind<ISystemLogBusinessLogic>().To<SystemLogBusinessLogic>();
            this.kernel.Bind<IHotelCityBusinessLogic>().To<HotelCityBusinessLogic>();
            this.kernel.Bind<ISettingBusinessLogic>().To<SettingBusinessLogic>();
            this.kernel.Bind<IZhunaHotelBusinessLogic>().To<ZhunaHotelBusinessLogic>();
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }
    }
}
