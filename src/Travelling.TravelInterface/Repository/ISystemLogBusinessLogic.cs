using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace Travelling.TravelInterface.Repository
{
    public interface ISystemLogBusinessLogic
    {
        int AddSystemLog(OperatingLog logDto);

        bool UpdateLogEndDate(int logId);

        PageObjectResult<OperatingLog> OperatingLogPageResult(OperatingLogSearchModel search);
    }
}
