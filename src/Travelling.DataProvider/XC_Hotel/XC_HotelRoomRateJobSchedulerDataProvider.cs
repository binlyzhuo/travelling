using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelRoomRateJobSchedulerDataProvider : BaseRecord<T_XC_HotelRoomRateJobScheduler>, IXC_HotelRoomRateJobSchedulerDataProvider
    {
        public XC_HotelRoomRateJobSchedulerDataProvider()
        {
            base.defaultDatabase = OTA_HotelDatabase;
        }

        public T_XC_HotelRoomRateJobScheduler HotelRoomRateJobSchedulerGetRecordToExecute()
        {
            Sql where = Sql.Builder.Where("SyncState in(0,1) and State=1");
            //Sql topSql = Sql.Builder.Where("SyncState=0").OrderBy("AddDate asc");
            return Top(1, where).SingleOrDefault();
        }

        public Page<T_XC_HotelRoomRateJobScheduler> GetHotelRoomRateJobPageResult(HotelRoomRateJobSearchModel search)
        {
            Sql where = Sql.Builder.Where("1=1");
            var pageResult = defaultDatabase.Page<T_XC_HotelRoomRateJobScheduler>(search.PageIndex, search.PageSize, where);
            return pageResult;
        }
    }
}
