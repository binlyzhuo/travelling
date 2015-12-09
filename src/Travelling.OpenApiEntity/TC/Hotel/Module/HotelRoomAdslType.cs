using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 宽带类型
    /// </summary>
    public enum HotelRoomAdslType
    {
        [Description("无宽带")]
        None=0,

         [Description("免费有线")]
        HaveAll=1,

         [Description("部免")]
        HavePart=2,

        [Description("有(全收)")]
        AllPay=3,

        [Description("有(全收)")]
        PartPay=4,

        [Description("免费有线")]
        FreeAdsl=5,


        [Description("免费无线")]
        FreeWifi=7
    }
}
