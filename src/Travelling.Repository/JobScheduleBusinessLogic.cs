using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Ninject;
using AutoMapper;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel;
using Travelling.ViewModel.Setting;
using Travelling.ViewModel.Admin;

namespace Travelling.Repository
{
    public class JobScheduleBusinessLogic : BaseLogic, IJobScheduleBusinessLogic
    {
        private readonly IJobSchedulerDataProvider jobData;
        private readonly IJobSchedulerLogDataProvider jobLogData;
        private readonly IXC_HotelRoomRateJobSchedulerDataProvider hotelRoomRateJobData;

        public JobScheduleBusinessLogic()
        {
            jobData = kernel.Get<IJobSchedulerDataProvider>();
            jobLogData = kernel.Get<IJobSchedulerLogDataProvider>();
            hotelRoomRateJobData = kernel.Get<IXC_HotelRoomRateJobSchedulerDataProvider>();
        }
        public List<JobScheduler> GetJobScheduler()
        {
            var jobs = jobData.GetJobSchedulers();
            var jobDto = Mapper.Map<List<T_JobScheduler>, List<JobScheduler>>(jobs);
            return jobDto;
        }

        public PageObjectResult<JobScheduler> GetJobSchedulerSearchResult(JobTaskSearchModel search)
        {
            var pageResult = jobData.GetJobSchedulerPageResult(search);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<JobScheduler>();
            var pageViewResult = new PageObjectResult<JobScheduler>()
            {
                Items = Mapper.Map<List<T_JobScheduler>, List<JobScheduler>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };

            return pageViewResult;
        }

        public bool AddNewJobTask(JobScheduler jobTaskDto)
        {
            var jobTaskDomain = AutoMapper.Mapper.Map<JobScheduler, T_JobScheduler>(jobTaskDto);
            jobTaskDomain.AddDate = DateTime.Now;
            int jobId = jobData.Save(jobTaskDomain);
            return jobId > 0;
        }

        public JobScheduler GetJobTaskDetailByJobID(int jobId)
        {
            var jobDomain = jobData.SingleOrDefault(jobId);
            var jobDto = AutoMapper.Mapper.Map<T_JobScheduler, JobScheduler>(jobDomain);
            return jobDto;
        }

        public bool UpdateJobTask(JobScheduler jobDto)
        {
            var jobDomain = jobData.SingleOrDefault(jobDto.ID);
            jobDomain.CronExpr = jobDto.CronExpr;
            jobDomain.GroupName = jobDto.GroupName;
            jobDomain.JobMethodName = jobDto.JobMethodName;
            jobDomain.JobName = jobDto.JobName;
            jobDomain.ProjectId = jobDto.ProjectId;
            jobDomain.State = jobDto.State;
            jobDomain.Remark = jobDto.Remark;

            bool updateResult = jobData.Update(jobDomain)>0;
            return updateResult;
        }

        public bool DeleteJobTask(int jobId)
        {
            bool updateResult = jobData.Delete(jobId);
            return updateResult;
        }

        public int AddJobTaskLog(JobSchedulerLog jobTaskLogDto)
        {
            var jobLogDomain = AutoMapper.Mapper.Map<JobSchedulerLog, T_JobSchedulerLog>(jobTaskLogDto);
            return jobLogData.Save(jobLogDomain);
        }

        public PageObjectResult<HotelRoomRateJobScheduler> GetHotelRoomRateJobSchedulerResult(HotelRoomRateJobSearchModel search)
        {
            var page = hotelRoomRateJobData.GetHotelRoomRateJobPageResult(search);
            if (page.TotalItems == 0)
                return new PageObjectResult<HotelRoomRateJobScheduler>();
            var pageViewResult = new PageObjectResult<HotelRoomRateJobScheduler>() {
                Items = Mapper.Map <List<T_XC_HotelRoomRateJobScheduler>,List <HotelRoomRateJobScheduler>>(page.Items),
                Page = page.CurrentPage,
                PageSize = page.ItemsPerPage,
                TotalCount = page.TotalItems,
                TotalPages = page.TotalPages
            };
            return pageViewResult;
        }

        public bool HotelRoomPriceSyncJobAdd(HotelRoomRateJobScheduler jobScheduleDto)
        {
            jobScheduleDto.AddDate = DateTime.Now;
            jobScheduleDto.SyncState = 0;

            var jobScheduleDomain = AutoMapper.Mapper.Map<HotelRoomRateJobScheduler, T_XC_HotelRoomRateJobScheduler>(jobScheduleDto);

            return hotelRoomRateJobData.Save(jobScheduleDomain)>0;
        }

        public HotelRoomRateJobScheduler GetHotelRoomRateJobScheduler(int jobId)
        {
            var jobDomain = hotelRoomRateJobData.SingleOrDefault(jobId);
            var jobDto = AutoMapper.Mapper.Map<T_XC_HotelRoomRateJobScheduler, HotelRoomRateJobScheduler>(jobDomain);
            return jobDto;
        }

        /// <summary>
        /// 修改酒店价格信息同步任务
        /// </summary>
        /// <param name="jobScheduleDto"></param>
        /// <returns></returns>
        public bool HotelRoomPriceSyncJobUpdate(HotelRoomRateJobScheduler jobScheduleDto)
        {
            var jobDomain = hotelRoomRateJobData.SingleOrDefault(jobScheduleDto.ID);
            jobDomain.StartDate = jobScheduleDto.StartDate;
            jobDomain.EndDate = jobScheduleDto.EndDate;
            jobDomain.State = jobScheduleDto.State;

            return hotelRoomRateJobData.Update(jobDomain)>0;
        }

        /// <summary>
        /// 删除酒店价格信息同步任务
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool HotelRoomPriceSyncJobDelete(int jobId)
        {
            return hotelRoomRateJobData.Delete(jobId);
        }
    }
}
