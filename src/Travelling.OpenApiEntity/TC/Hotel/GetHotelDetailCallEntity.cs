using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelDetailCallEntity : TongChengBaseCallEntity
    {
        
        public int HotelId { set; get; }
        public int MapType = 2;
    }
}
