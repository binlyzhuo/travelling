using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Scenery.Module
{
    public enum SceneryTicketPayType
    {
        [Description("景区现付")]
        PayAtScenery=0,

        [Description("在线支付")]
        PayOnline=1,

        [Description("其他支付")]
        Other=2

    }
}
