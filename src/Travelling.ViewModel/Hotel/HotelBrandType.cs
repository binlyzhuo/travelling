using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Hotel
{
    /// <summary>
    /// 酒店品牌类型
    /// </summary>
    public enum HotelBrandType
    {
        /// <summary>
        /// 所有类型
        /// </summary>
        [Description("所有类型")]
        All = 0,

        /// <summary>
        /// 经济
        /// </summary>
        [Description("经济")]
        Economic = 1,

        /// <summary>
        /// 舒适
        /// </summary>
        [Description("舒适")]
        Comfortable = 2,

        /// <summary>
        /// 高档
        /// </summary>
        [Description("高档")]
        TopGrade = 3,

        /// <summary>
        /// 豪华
        /// </summary>
        [Description("豪华")]
        Costly=4
    }
}
