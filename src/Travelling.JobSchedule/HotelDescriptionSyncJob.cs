using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.CommonLibrary;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Ninject;
using Travelling.Repository;
using Travelling.FrameWork;

namespace Travelling.JobSchedule
{
    public class HotelDescriptionSyncJob : BaseJobTask, IJob
    {
        

        public HotelDescriptionSyncJob()
        {
            
        }

        public void Execute(IJobExecutionContext context)
        {
            //LogHelper.Info("sync the hotel descriptions");
            JobSchedulerLog log = new JobSchedulerLog();
            log.AddDate = DateTime.Now;
            log.EndDate = DateTime.Now;
            log.JobId = 0;
            log.JobName = "HotelDescriptionSyncJob";
            log.Remark = "同步酒店详细信息";
            log.StartDate = DateTime.Now;
            jobTaskBusiness.AddJobTaskLog(log);

            EmailService.SendMail("binlyzhuo@outlook.com","job executing","executing jobs","");
        }


    }
}
