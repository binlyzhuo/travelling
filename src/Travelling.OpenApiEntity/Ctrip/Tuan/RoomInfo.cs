using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class RoomInfo
    {
        public int RoomID { set; get; }

        public List<RoomStatusItem> roomstatusItems { set; get; }
    }
}
