using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Web.Helpers
{
    public enum TopMenuSetting
    {
        [MenuUrl("首页","/",0)]
        Home=0,

        [MenuUrl("酒店预定", "/JiuDian/Index", 1)]
        Hotel = 1,

        [MenuUrl("景点门票", "/Scenery", 2)]
        Scenery=2,

        [MenuUrl("品牌酒店", "/PinPai", 3)]
        HotelBrand=3,

        [MenuUrl("团购", "/Tuan", 4)]
        Group=4
    }
}
