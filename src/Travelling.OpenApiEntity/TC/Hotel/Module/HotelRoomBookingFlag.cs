using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 预定标示
    /// </summary>
    public enum HotelRoomBookingFlag
    {
        /// <summary>
        /// 可预订
        /// </summary>
        [Description("可预订")]
        BookAble=0,

        /// <summary>
        /// 价格全部未定
        /// </summary>
        [Description("价格全部未定")]
        PriceUnfix=1,

        /// <summary>
        /// 全部满房
        /// </summary>
        [Description("全部满房")]
        FullHourse=2,

        /// <summary>
        /// 部分价格未定
        /// </summary>
        [Description("部分价格未定")]
        PartPriceUnfix=3,

        /// <summary>
        /// 部分满房
        /// </summary>
        [Description("部分满房")]
        PartFullHourse=4,

        /// <summary>
        /// 提前入住
        /// </summary>
        [Description("提前入住")]
        CheckinAhead=5,

        /// <summary>
        /// 连住
        /// </summary>
        [Description("连住")]
        ContinueCheckin=6
    }
}
