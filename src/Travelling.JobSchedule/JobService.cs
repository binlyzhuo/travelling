using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Job;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.JobSchedule
{
    public class JobService : IJobScheduler
    {
        IJobScheduleBusinessLogic jobScheduleBusiness;
        private readonly StandardKernel kernel;
        public JobService()
        {
            kernel = new StandardKernel(new NinjectJobTask());
            jobScheduleBusiness = kernel.Get<IJobScheduleBusinessLogic>();
        }

        public List<JobScheduler> GetJobScheduler()
        {
            var items = jobScheduleBusiness.GetJobScheduler();
            return items;
        }
    }
}
