using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.JobSchedule
{
    public class HotelDeleteOverduePriceSyncJob:BaseJobTask,IJob
    {
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusinessLogic;


        public HotelDeleteOverduePriceSyncJob()
        {
            hotelDataSyncBusinessLogic = kernel.Get<IHotelDataSyncBusinssLogic>();
        }

        public void Execute(IJobExecutionContext context)
        {
            JobSchedulerLog log = new JobSchedulerLog();
            DateTime start = DateTime.Now;
            hotelDataSyncBusinessLogic.DeleteOverdueRoomRatePlanDateOfCity();
            log.StartDate = start;
            log.EndDate = DateTime.Now;
            log.JobId = 0;
            log.JobName = "HotelDeleteOverduePriceSyncJob";
            log.Remark = "删除酒店过期价格数据";
            
            jobTaskBusiness.AddJobTaskLog(log);
        }
    }
}
