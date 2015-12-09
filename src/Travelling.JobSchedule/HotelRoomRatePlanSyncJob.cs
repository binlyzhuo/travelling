using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Travelling.TravelInterface.Repository;
using Travelling.CommonLibrary;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.JobSchedule
{
    public class HotelRoomRatePlanSyncJob : BaseJobTask, IJob
    {

        private readonly IHotelInfoBusinessLogic hotelinfoBusiness;
        private readonly IHotelDataSyncBusinssLogic hotelSyncBusiness;

        public HotelRoomRatePlanSyncJob()
        {
            hotelinfoBusiness = kernel.Get<IHotelInfoBusinessLogic>();
            hotelSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();
        }

        public void Execute(IJobExecutionContext context)
        {
            JobSchedulerLog log = new JobSchedulerLog();
            log.AddDate = DateTime.Now;
            log.EndDate = DateTime.Now;
            log.JobId = 0;
            log.JobName = "HotelRoomRatePlanSyncJob";
            log.Remark = "同步酒店价格计划";
            log.StartDate = DateTime.Now;
            jobTaskBusiness.AddJobTaskLog(log);
        }
    }
}
