using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IXC_HotelRoomRateJobSchedulerDataProvider:IDataProvider<T_XC_HotelRoomRateJobScheduler>
    {
        T_XC_HotelRoomRateJobScheduler HotelRoomRateJobSchedulerGetRecordToExecute();

        Page<T_XC_HotelRoomRateJobScheduler> GetHotelRoomRateJobPageResult(HotelRoomRateJobSearchModel search);
    }
}
