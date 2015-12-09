using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
using PetaPoco;
using QuartzProject.Code;
using Quartz.Spi;
using Quartz.Impl.Triggers;

namespace QuartzProject
{
    public class Global : System.Web.HttpApplication
    {
        IScheduler sched;
        protected void Application_Start(object sender, EventArgs e)
        {
            ISchedulerFactory sf = new StdSchedulerFactory();

            sched = sf.GetScheduler();
            JobKey jobKey = new JobKey("my job","Job Group");
            
            string cron = "0/30 * * * * ?";
            RunLogJob runlogJob = new RunLogJob();

            IJobDetail job = JobBuilder.Create<RunLogJob>().WithIdentity(jobKey).Build();
            IOperableTrigger trigger = new CronTriggerImpl("trigName","group1",cron);
            sched.ScheduleJob(job,trigger);
            sched.Start();
        }
    }
}