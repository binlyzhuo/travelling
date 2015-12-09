using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;
using Travelling.ViewModel.Setting;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class JobSchedulerDataProvider : BaseRecord<T_JobScheduler>, IJobSchedulerDataProvider
    {
        public JobSchedulerDataProvider()
        {
            this.defaultDatabase = TravelDatabase ;
        }

        public List<T_JobScheduler> GetJobSchedulers()
        {
            Sql sqlBuild = Sql.Builder.Where("State=1");
            return defaultDatabase.Query<T_JobScheduler>(sqlBuild).ToList();
        }

        public Page<T_JobScheduler> GetJobSchedulerPageResult(JobTaskSearchModel searchModel)
        {
            Sql whereSql = Sql.Builder.Where("1=1");
            if(!string.IsNullOrEmpty(searchModel.JobName))
            {
                whereSql.Where("JobName like @0","%"+searchModel.JobName+"%");
            }
            if(searchModel.JobState!=null)
            {
                whereSql.Where("State=@0",searchModel.JobState);
            }
            var pageResult = defaultDatabase.Page<T_JobScheduler>(searchModel.PageIndex,searchModel.PageSize,whereSql);
            return pageResult;

        }
    }
}
