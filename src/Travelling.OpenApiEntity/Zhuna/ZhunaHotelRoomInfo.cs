using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelRoomInfo
    {
        public int rid { set; get; }
        public string title { set; get; }
        public string adsl { set; get; }
        public string bed { set; get; }
        public string area { set; get; }
        public string floor { set; get; }
        public string status { set; get; }
        public string notes { set; get; }

        public string AvailableAmount { set; get; }

        public List<ZhunaHotelRoomImgInfo> img { set; get; }
        public List<ZhunaHotelRoomPlan> plans { set; get; }
    }
}
