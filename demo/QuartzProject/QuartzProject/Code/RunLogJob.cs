using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using PetaPoco;
using QuartzProject.Models;

namespace QuartzProject.Code
{
    public class RunLogJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (Database db = new Database("Job"))
            {
                RunLog log = new RunLog() { AddDate = DateTime.Now };
                db.Insert(log);
            }
        }
    }
}