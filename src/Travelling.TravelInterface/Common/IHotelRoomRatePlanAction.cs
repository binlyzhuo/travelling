using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Common
{
    public interface IHotelRoomRatePlanAction
    {
        List<HotelRoomRatePlanInfo> GetHotelRoomRatePlan(int hotelId, DateTime start, DateTime end);
    }
}
