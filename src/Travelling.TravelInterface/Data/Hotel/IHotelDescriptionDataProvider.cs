using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data.Hotel
{
    /// <summary>
    /// 酒店静态信息数据源接口
    /// </summary>
    public interface IHotelDescriptionDataProvider : IDataProvider<T_XC_HotelDescription>
    {
        
    }
}
