using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Scenery.Module
{
    /// <summary>
    /// 附近景区信息
    /// </summary>
    public class SceneryNearInfo
    {
        /// <summary>
        /// 景区名称
        /// </summary>
        public string SceneryName { set; get; }

        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryId { set; get; }

        /// <summary>
        /// 同程价格
        /// </summary>
        public int AmountAdvice { set; get; }

        /// <summary>
        /// 景区星级
        /// </summary>
        public int GradeId { set; get; }
    }
}
