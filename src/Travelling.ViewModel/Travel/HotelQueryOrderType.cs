using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店查询排序方式
    /// </summary>
    public enum HotelQueryOrderType
    {
        /// <summary>
        /// 最受欢迎
        /// </summary>
        CommonRate=0,

        /// <summary>
        /// 价格降序
        /// </summary>
        PriceDesc=1,

        /// <summary>
        /// 价格升序
        /// </summary>
        PriceAsc=2,

        /// <summary>
        /// 评分降序
        /// </summary>
        UserRateDesc=3,

        /// <summary>
        /// 评分升序
        /// </summary>
        UserRateAsc=4,

        /// <summary>
        /// 星级降序
        /// </summary>
        StarDesc=5,
        
        /// <summary>
        /// 星级升序
        /// </summary>
        StarAsc=6
    }
}
