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
    public class OperatingLogDataProvider : BaseRecord<T_OperatingLog>, IOperatingLogDataProvider
    {
        public OperatingLogDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }

        public Page<T_OperatingLog> OperatingLogPageResult(OperatingLogSearchModel search)
        {
            Sql where = Sql.Builder.Where("1=1");
            return defaultDatabase.Page<T_OperatingLog>(search.PageIndex,search.PageSize,where);
        }
    }
}
