using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IOperatingLogDataProvider : IDataProvider<T_OperatingLog>
    {
        Page<T_OperatingLog> OperatingLogPageResult(OperatingLogSearchModel search);
    }
}
