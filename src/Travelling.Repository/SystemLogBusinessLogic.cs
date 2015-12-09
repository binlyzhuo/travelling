using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.DataLayer;

namespace Travelling.Repository
{
    public class SystemLogBusinessLogic : BaseLogic, ISystemLogBusinessLogic
    {
        private readonly IOperatingLogDataProvider operatingLogData;
        public SystemLogBusinessLogic()
        {
            operatingLogData = kernel.Get<IOperatingLogDataProvider>();
        }

        public int AddSystemLog(OperatingLog logDto)
        {
            var logDomain = AutoMapper.Mapper.Map<OperatingLog, T_OperatingLog>(logDto);
            int logid = operatingLogData.Save(logDomain);
            return logid;
        }

        public bool UpdateLogEndDate(int logId)
        {
            //operatingLogData.Update();
            var logDomain = operatingLogData.SingleOrDefault(logId);
            logDomain.EndDate = DateTime.Now;
            return operatingLogData.Update(logDomain) > 0;
        }

        public PageObjectResult<OperatingLog> OperatingLogPageResult(OperatingLogSearchModel search)
        {
            var pageResult = operatingLogData.OperatingLogPageResult(search);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<OperatingLog>();
            var pageViewResult = new PageObjectResult<OperatingLog>()
            {
                Items = AutoMapper.Mapper.Map<List<T_OperatingLog>, List<OperatingLog>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };
            return pageViewResult;
        }
    }
}
