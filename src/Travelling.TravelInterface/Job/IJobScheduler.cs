using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.TravelInterface.Job
{
    public interface IJobScheduler
    {
        List<JobScheduler> GetJobScheduler();
    }
}
