using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using Travelling.JobSchedule;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.Web.Helpers
{
    public static class JobTaskHelper
    {
        public static List<string> GetJobMethods()
        {
            JobTaskLog jobTaskLog;

            var jobTaskMethods = HttpRuntime.Cache.Get("JobMethods") as List<string>;
            if (jobTaskMethods == null)
            {
                jobTaskMethods = new List<string>();
                string appBaseDir = System.AppDomain.CurrentDomain.BaseDirectory;
                Assembly assembly = Assembly.LoadFrom(appBaseDir + "\\bin" + "\\Travelling.JobSchedule.dll");
                Type[] types = assembly.GetTypes();
                foreach (Type t in types)
                {
                    //if(t.GetInterface("",false))
                    Type ijobType = t.GetInterface("Quartz.IJob");
                    if (ijobType != null)
                    {
                        jobTaskMethods.Add(t.FullName);
                    }
                }
                HttpRuntime.Cache.Insert("JobMethods", jobTaskMethods);
            }

            return jobTaskMethods;
        }

        public static string GetNextRunTime(JobScheduler job)
        {
            return "";
        }
    }
}