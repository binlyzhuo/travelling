using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;

namespace Travelling.DataProvider.HotelSyncRecord
{
    /// <summary>
    /// 定时任务日志
    /// </summary>
    public class JobSchedulerLogDataProvider : BaseRecord<T_JobSchedulerLog>, IJobSchedulerLogDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public JobSchedulerLogDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }
    }
}
