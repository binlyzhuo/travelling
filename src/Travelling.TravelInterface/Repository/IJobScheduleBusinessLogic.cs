using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Setting;

namespace Travelling.TravelInterface.Repository
{
    public interface IJobScheduleBusinessLogic
    {
        List<JobScheduler> GetJobScheduler();

        PageObjectResult<JobScheduler> GetJobSchedulerSearchResult(JobTaskSearchModel search);

        bool AddNewJobTask(JobScheduler jobTaskDto);

        JobScheduler GetJobTaskDetailByJobID(int jobId);

        bool UpdateJobTask(JobScheduler jobDto);

        bool DeleteJobTask(int jobId);

        int AddJobTaskLog(JobSchedulerLog jobTaskLogDto);

        PageObjectResult<HotelRoomRateJobScheduler> GetHotelRoomRateJobSchedulerResult(HotelRoomRateJobSearchModel search);

        bool HotelRoomPriceSyncJobAdd(HotelRoomRateJobScheduler jobScheduleDto);

        HotelRoomRateJobScheduler GetHotelRoomRateJobScheduler(int jobId);

        bool HotelRoomPriceSyncJobUpdate(HotelRoomRateJobScheduler jobScheduleDto);

        bool HotelRoomPriceSyncJobDelete(int jobId);
    }
}
