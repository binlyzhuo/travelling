using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Repository;

namespace Travelling.JobSchedule
{
    public class BaseJobTask
    {
        /// <summary>
        /// 依赖注入对象
        /// </summary>
        protected readonly StandardKernel kernel;

        protected readonly IJobScheduleBusinessLogic jobTaskBusiness;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseJobTask()
        {
            kernel = new Ninject.StandardKernel(new NinjectJobTask());
            jobTaskBusiness = kernel.Get<IJobScheduleBusinessLogic>();
        }
    }
}
