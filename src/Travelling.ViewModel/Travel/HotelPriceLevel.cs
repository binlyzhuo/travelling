using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Travelling.FrameWork;
using Travelling.ViewModel.Attributes;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店价格查询区间
    /// </summary>
    public enum HotelPriceLevel
    {
        /// <summary>
        /// 价格不限
        /// </summary>
        [Description("不限")]
        [NumberRangeAttribute(1, 99999)]
        All = 0,

        /// <summary>
        /// ￥600以上
        /// </summary>
        [Description("￥600以上")]
        [NumberRangeAttribute(600,9999)]
        Over600 = 600,

        /// <summary>
        /// ￥451-600
        /// </summary>
        [Description("￥451-600")]
        [NumberRangeAttribute(451, 600)]
        Over451 = 451,

        /// <summary>
        /// ￥301-450
        /// </summary>
        [Description("￥301-450")]
        [NumberRangeAttribute(301, 450)]
        Over301 = 301,

        /// <summary>
        /// ￥150-300
        /// </summary>
        [Description("￥150-300")]
        [NumberRangeAttribute(150, 300)]
        Over150 = 150,

        /// <summary>
        /// ￥150以下
        /// </summary>
        [Description("￥150以下")]
        [NumberRangeAttribute(1, 150)]
        Below150 = 149
    }
}
