using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;
using Travelling.CommonLibrary;
using Travelling.TravelInterface.Job;
using Travelling.JobSchedule;
using System.Reflection;
using Quartz.Spi;
using Quartz.Impl.Triggers;

namespace Travelling.Job
{
    public class Global : System.Web.HttpApplication
    {
        public static IScheduler scheduler;
        protected void Application_Start(object sender, EventArgs e)
        {
            LogHelper.LogConfig(Server.MapPath(@"log4net.config"));
            JobTaskMapper.Mapper();
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
            InitJob();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            LogHelper.Error(ex);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            if(scheduler!=null)
            {
                scheduler.Shutdown(true);
            }
        }

        public static void InitJob()
        {
            IJobScheduler jobService = new JobService();
            var jobs = jobService.GetJobScheduler();


            if (jobs != null && jobs.Count > 0)
            {
                var assay = Assembly.LoadFrom(HttpContext.Current.Server.MapPath("/bin/Travelling.JobSchedule.dll"));
                scheduler.Clear();
                foreach (var job in jobs)
                {

                    JobKey jobkey = new JobKey("JobTask" + job.ID, job.GroupName);
                    var fullType = assay.CreateInstance(job.JobMethodName);
                    IJobDetail jobDetail = JobBuilder.Create(fullType.GetType()).WithIdentity(jobkey).Build();
                    IOperableTrigger trigger = new CronTriggerImpl("trigName" + job.ID, "group1", job.CronExpr);

                    var dt = trigger.GetNextFireTimeUtc();
                    
                    scheduler.ScheduleJob(jobDetail, trigger);

                }
            }

            scheduler.Start();
        }
    }
}