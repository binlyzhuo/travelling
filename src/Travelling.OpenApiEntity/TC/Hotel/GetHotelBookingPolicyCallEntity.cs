using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelBookingPolicyCallEntity:TongChengBaseCallEntity
    {
        public int roomTypeId { set; get; }
        public DateTime comeDate { set; get; }
        public DateTime leaveDate { set; get; }
        public string comeTime { set; get; }
        public int roomCount { set; get; }
        public int pricePolicyId { set; get; }
    }
}
