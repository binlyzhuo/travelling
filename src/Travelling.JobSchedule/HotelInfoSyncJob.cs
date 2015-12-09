using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Repository;
using Ninject;

namespace Travelling.JobSchedule
{
    public class HotelInfoSyncJob:BaseJobTask,IJob
    {
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusinessLogic;
        public HotelInfoSyncJob()
        {
            hotelDataSyncBusinessLogic = kernel.Get<IHotelDataSyncBusinssLogic>();

        }

        public void Execute(IJobExecutionContext context)
        {
            hotelDataSyncBusinessLogic.InitHotelSyncInfoData();
        }

        private void SyncLog(string msg)
        {

        }
    }
}
