﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelChainReturnEntity:ZhunaBaseReturnEntity
    {
        public List<ZhunaHotelChainInfo> reqdata { set; get; }
    }
}
