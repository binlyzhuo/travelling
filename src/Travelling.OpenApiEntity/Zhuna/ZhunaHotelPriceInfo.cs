using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelPriceInfo
    {
        public int zid { set; get; }
        public string eid { set; get; }
        public string tm1 { set; get; }
        public string tm2 { set; get; }
        public string status { set; get; }

        public string Promotion { set; get; }

        public List<ZhunaHotelRoomInfo> rooms { set; get; }
    }
}
