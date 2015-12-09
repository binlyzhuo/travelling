using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC;

namespace Travelling.OpenApiEntity.Scenery
{
    /// <summary>
    /// 获取价格日历接口请求实体
    /// </summary>
    public class GetPriceCalendarCallEntity : TongChengBaseCallEntity
    {
        public int policyId { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }
        public bool showDetail { set; get; }
    }
}
