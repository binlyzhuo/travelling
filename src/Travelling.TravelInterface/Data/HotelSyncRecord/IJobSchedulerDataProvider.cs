using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Setting;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IJobSchedulerDataProvider : IDataProvider<T_JobScheduler>
    {
        List<T_JobScheduler> GetJobSchedulers();

        Page<T_JobScheduler> GetJobSchedulerPageResult(JobTaskSearchModel searchModel);
    }
}
