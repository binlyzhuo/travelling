using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelDetailReturnEntity : TongChengBaseReturnEntity
    {
        public TCHotelDetailInfo HotelDetailInfo { set; get; }
    }
}
