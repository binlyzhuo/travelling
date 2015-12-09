using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelSearchReturnEntity:ZhunaBaseReturnEntity
    {
        public List<ZhunaHotelInfo> reqdata { set; get; }
    }
}
