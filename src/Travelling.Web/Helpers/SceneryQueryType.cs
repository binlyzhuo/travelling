using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Web.Helpers
{
    /// <summary>
    /// 景区查询条件
    /// </summary>
    public enum SceneryQueryType
    {
        /// <summary>
        /// 省份
        /// </summary>
        Province = 0,

        /// <summary>
        /// 主题
        /// </summary>
        Theme = 1,

        /// <summary>
        /// 星级
        /// </summary>
        Star = 2,

        /// <summary>
        /// 城市
        /// </summary>
        City = 3
    }
}
