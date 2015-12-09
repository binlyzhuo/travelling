using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelpicReturnEntity:ZhunaBaseReturnEntity
    {
        public Dictionary<string, ZhunaHotelPicInfo> reqdata { set; get; }
        //public List<Dictionary<int,ZhunaHotelPicInfo>> 
    }
}
