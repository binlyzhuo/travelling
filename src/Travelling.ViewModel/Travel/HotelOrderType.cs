using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店订单状态
    /// </summary>
    public enum HotelOrderType
    {
        /// <summary>
        /// 已下单
        /// </summary>
        ForConfirm=0,

        /// <summary>
        /// 已确认
        /// </summary>
        Confirmed=1,

        /// <summary>
        /// 已取消
        /// </summary>
        Cancel = 2
    }
}
