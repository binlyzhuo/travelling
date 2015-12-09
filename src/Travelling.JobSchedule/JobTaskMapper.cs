using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.JobSchedule
{
    public class JobTaskMapper
    {
        public static void Mapper()
        {
            AutoMapper.Mapper.CreateMap<T_JobScheduler, JobScheduler>();
            AutoMapper.Mapper.CreateMap<T_JobSchedulerLog, JobSchedulerLog>();
            AutoMapper.Mapper.CreateMap<JobSchedulerLog, T_JobSchedulerLog>();
        }
    }
}
