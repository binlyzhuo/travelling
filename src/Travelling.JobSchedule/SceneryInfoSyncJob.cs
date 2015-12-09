using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.CommonLibrary;

namespace Travelling.JobSchedule
{
    public class SceneryInfoSyncJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //hotelSyncBusiness.DeleteOverdueData();
            //hotelinfoBusiness.DeleteOverdueRoomRatePlans();
            LogHelper.Info("sync the scenery infoamtion");

            // 删除过期
        }
    }
}
