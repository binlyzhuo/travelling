using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.HotelSyncRecord;

namespace Travelling.TravelInterface.Common
{
    public interface IHotelRoomInfoAction
    {
        List<T_XC_HotelRoomInfo> GetHotelRoomsByHotelID(int hotelID);
    }
}
