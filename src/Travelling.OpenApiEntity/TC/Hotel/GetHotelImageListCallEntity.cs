using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelImageListCallEntity:TongChengBaseCallEntity
    {
        public int hotelId { set; get; }
        public int page{set;get;}
        public int pageSize { set; get; }
    }
}
