using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelRoomsMultiCallEntity:TongChengBaseCallEntity
    {
        public List<int> HotelIdList { set; get; }
        public DateTime comeDate { set; get; }
        public DateTime leaveDate { set; get; }
    }
}
