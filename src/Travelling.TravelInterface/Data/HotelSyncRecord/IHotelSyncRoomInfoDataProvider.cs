using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IXC_HotelRoomInfoDataProvider : IDataProvider<T_XC_HotelRoomInfo>
    {
        List<HotelRoomPrimaryInfo> GetHotelRoomInfosAndRatePlan(int hotelId, int cityId, DateTime start, DateTime end);

        T_XC_HotelRoomInfo GetHotelRoomInfoByRoomTypeCode(int roomTypeCode);

        HotelRoomPrimaryInfo GetHotelRoomInfo(int hotelId, int roomTypeCode, int cityId = 0);

        List<HotelRoomPriceInfo> HotelRoomInfoPriceQuery(string hotelids, DateTime start, DateTime end, int cityId);

        List<T_XC_HotelRoomInfo> GetHotelRoomsByHotelID(int hotelID);
    }
}
