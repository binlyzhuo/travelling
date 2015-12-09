using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.JobSchedule;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.Job
{
    public partial class _default : System.Web.UI.Page
    {
        public List<JobScheduler> JobTasks;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            JobService jobService = new JobService();
            JobTasks = jobService.GetJobScheduler();
            if(JobTasks==null)
            {
                JobTasks = new List<JobScheduler>();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string GetNextRunTime(JobScheduler job)
        {
            JobKey jobkey = new JobKey("JobTask" + job.ID, job.GroupName);

            var jobTriggers = Global.scheduler.GetTriggersOfJob(jobkey);
            if (jobTriggers != null && jobTriggers.Count > 0)
            {
                var tg = jobTriggers[0];
                DateTimeOffset? utcDt = tg.GetNextFireTimeUtc();
                var local = ((DateTimeOffset)utcDt).ToLocalTime();
                return local.ToString();
            }
            return "";
        }
    }
}