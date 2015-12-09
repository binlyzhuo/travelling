using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Travelling.FrameWork;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 景区星级
    /// </summary>
    public enum SceneryStarLevel
    {
        /// <summary>
        /// 全部
        /// </summary>
        [NumberRangeAttribute(0,5)]
        [Description("全部")]
        [OrderNumberAttribute(1)]
        All = 0,

        /// <summary>
        /// 5星
        /// </summary>
         [NumberRangeAttribute(5, 5)]
         [Description("5A")]
         [OrderNumberAttribute(2)]
        Star5=5,

        /// <summary>
         /// 4星
        /// </summary>
        [NumberRangeAttribute(4, 4)]
        [Description("4A")]
        [OrderNumberAttribute(3)]
        Star4=4,

        /// <summary>
        /// 3星
        /// </summary>
        [NumberRangeAttribute(3, 3)]
        [Description("3A")]
        [OrderNumberAttribute(4)]
        Star3=3,

        /// <summary>
        /// 其他
        /// </summary>
        [NumberRangeAttribute(0, 2)]
        [Description("其他")]
        [OrderNumberAttribute(5)]
        StarOther=2
    }
}
